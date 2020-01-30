using AutoMapper;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TeduShopAPIDapperCore.Mapping;
using TeduShopData.Dtos;
using TeduShopData.Models;
using TeduShopData.ViewModel.System;

namespace TeduShopAPIDapperCore.Controllers
{
    [Route("api/[controller]")]
    public class FunctionController : ControllerBase
    {
        private readonly string _connectionString;
        private readonly IMapper _mapper;

        public FunctionController(IConfiguration configuration, IMapper mapper)
        {
            _connectionString = configuration.GetConnectionString("DbConnectionString");
            _mapper = mapper;
        }

        // GET: api/Role
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    await conn.OpenAsync();

                var paramaters = new DynamicParameters();
                var model = await conn.QueryAsync<Functions>("Get_Function_All", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                IEnumerable<FunctionViewModel> modelVm = _mapper.Map<IEnumerable<FunctionViewModel>>(model);

                return Ok(modelVm);
            }
        }
        // GET: api/Role/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                var paramaters = new DynamicParameters();
                paramaters.Add("@id", id);

                var result = await conn.QueryAsync<Functions>("Get_Function_ById", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                return Ok(result.Single());
            }
        }
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

                var result = await conn.QueryAsync<Functions>("Get_Function_AllPaging", paramaters, null, null, System.Data.CommandType.StoredProcedure);

                int totalRow = paramaters.Get<int>("@totalRow");

                var pagedResult = new PagedResult<Functions>()
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
        public async Task<IActionResult> Post([FromBody] FunctionViewModel functionViewModel)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                var paramaters = new DynamicParameters();
                paramaters.Add("@id", functionViewModel.ID);
                paramaters.Add("@name", functionViewModel.Name);
                paramaters.Add("@url", functionViewModel.URL);
                paramaters.Add("@displayOrder", functionViewModel.DisplayOrder);
                paramaters.Add("@parentId", functionViewModel.ParentId);
                paramaters.Add("@status", functionViewModel.Status);
                paramaters.Add("@cssClass", functionViewModel.IconCss);
                await conn.ExecuteAsync("Create_Function", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                return Ok();
            }
        }
        // PUT: api/Role/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([Required]Guid id, [FromBody] FunctionViewModel functionViewModel)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                var paramaters = new DynamicParameters();
                paramaters.Add("@id", id);
                paramaters.Add("@name", functionViewModel.Name);
                paramaters.Add("@url", functionViewModel.URL);
                paramaters.Add("@parentId", functionViewModel.ParentId);
                paramaters.Add("@displayOrder", functionViewModel.DisplayOrder);
                paramaters.Add("@status", functionViewModel.Status);
                paramaters.Add("@cssClass", functionViewModel.IconCss);

                await conn.ExecuteAsync("Update_Function", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                return Ok();
            }
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                var paramaters = new DynamicParameters();
                paramaters.Add("@id", id);
                await conn.ExecuteAsync("Delete_Function_ById", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                return Ok();
            }
        }
    }
}
