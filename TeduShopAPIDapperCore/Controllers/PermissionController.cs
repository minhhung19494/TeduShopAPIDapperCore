﻿using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TeduShopAPIDapperCore.Extensions;
using TeduShopData.ViewModel.System;

namespace TeduShopAPIDapperCore.Controllers
{
    [Route("api/[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly string _connectionString;

        public PermissionController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DbConnectionString");
        }

        [HttpGet("function-actions")]
        public async Task<IActionResult> GetAllWithPermission()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    await conn.OpenAsync();

                var result = await conn.QueryAsync<FunctionActionViewModel>("Get_Function_WithActions", null, null, null, System.Data.CommandType.StoredProcedure);

                return Ok(result);
            }
        }
        [HttpGet("{roleId}/role-permissions")]
        public async Task<IActionResult> GetAllRolePermissions(Guid? roleId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                var paramaters = new DynamicParameters();
                paramaters.Add("@roleId", roleId);

                var result = await conn.QueryAsync<PermissionViewModel>("Get_Permission_ByRoleId", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                return Ok(result);
            }
        }
        [HttpPost("{roleId}/save-permissions")]
        public async Task<IActionResult> SavePermissions(Guid roleId, [FromBody]List<PermissionViewModel> permissions)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                var dt = new DataTable();
                dt.Columns.Add("RoleId", typeof(Guid));
                dt.Columns.Add("FunctionId", typeof(string));
                dt.Columns.Add("ActionId", typeof(string));
                foreach (var item in permissions)
                {
                    dt.Rows.Add(roleId, item.FunctionId, item.ActionId);
                }
                var paramaters = new DynamicParameters();
                paramaters.Add("@roleId", roleId);
                paramaters.Add("@permissions", dt.AsTableValuedParameter("dbo.Permission"));
                await conn.ExecuteAsync("Create_Permission", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                return Ok();
            }
        }
        [HttpGet("functions-view")]
        public async Task<IActionResult> GetAllFunctionByPermission()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                var paramaters = new DynamicParameters();
                paramaters.Add("@userId", User.GetUserId());

                var result = await conn.QueryAsync<FunctionViewModel>("Get_Function_ByPermission", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                return Ok(result);
            }
        }

    }
}
