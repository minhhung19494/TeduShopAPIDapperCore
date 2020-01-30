
using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TeduShopAPIDapperCore.Extensions;
using TeduShopData.Dtos;
using TeduShopData.Models;
using TeduShopData.ViewModel.System;

namespace TeduShopAPIDapperCore.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : ControllerBase

    {
        private readonly RoleManager<AppRoles> _roleManager;
        private readonly string _connectionString;
        public RoleController(RoleManager<AppRoles> roleManager, IConfiguration configuration)
        {
            _roleManager = roleManager;
            _connectionString = configuration.GetConnectionString("DbConnectionString");
        }
        //GET: api/Role
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                }
                var parameters = new DynamicParameters();
                var result = await conn.QueryAsync<AppRoles>("Get_Role_All", parameters, null, null, System.Data.CommandType.StoredProcedure);
                return Ok(result);
            }
        }
        //GET: api/Role/5
        [HttpGet("{id}")]

        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _roleManager.FindByIdAsync(id));
        }
        //GET: api/Role/paging
        [HttpGet("paging")]
        public async Task<IActionResult> GetPaging(string keyword, int pageIndex, int pageSize)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    await conn.OpenAsync();

                var paramaters = new DynamicParameters();
                paramaters.Add("@keyword", keyword);
                paramaters.Add("@pageIndex", pageIndex);
                paramaters.Add("@pageSize", pageSize);
                paramaters.Add("@totalRow", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                var result = await conn.QueryAsync<AppRoles>("Get_Role_AllPaging", paramaters, null, null, System.Data.CommandType.StoredProcedure);

                int totalRow = paramaters.Get<int>("@totalRow");

                var pagedResult = new PagedResult<AppRoles>()
                {
                    Items = result.ToList(),
                    TotalRow = totalRow,
                    PageIndex = pageIndex,
                    PageSize = pageSize
                };
                return Ok(pagedResult);
            }
        }
        // POST: api/Role
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ApplicationRoleViewModel appRolesViewModel)
        {
            var newAppRole = new AppRoles();
            newAppRole.UpdateApplicationRole(appRolesViewModel, "add");
            var result = await _roleManager.CreateAsync(newAppRole);
            if (result.Succeeded)
                return Ok();
            return BadRequest();
        }

        // PUT: api/Role/5
        [HttpPut("update")]
        public async Task<IActionResult> Put([FromBody] ApplicationRoleViewModel appRolesViewModel)
        {
            var appRole = await _roleManager.FindByIdAsync(appRolesViewModel.Id.ToString());
            appRole.UpdateApplicationRole(appRolesViewModel, "update");
            var result = await _roleManager.UpdateAsync(appRole);
            if (result.Succeeded)
                return Ok();
            return BadRequest();
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
                return Ok();
            return BadRequest();
        }
    }
}
