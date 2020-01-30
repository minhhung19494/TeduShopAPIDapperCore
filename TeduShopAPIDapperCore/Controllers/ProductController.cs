using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TeduShopData.Models;
using TeduShopData.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TeduShopAPIDapperCore.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly string _connectionString;

        public ProductController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DbConnectionString");
        }
        // GET api/<controller>/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Products> GetByIdAsync(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                var parameter = new DynamicParameters();
                parameter.Add("@id", id);
                var result = await conn.QueryAsync<Products>("Get_Product_By_Id", parameter, null, null, System.Data.CommandType.StoredProcedure);
                return result.Single();
            };
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<Products>> Get()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                var result = await conn.QueryAsync<Products>("Get_All_Products", null, null, null, System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<int> Post(Products product)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                var parameter = new DynamicParameters();
                parameter.Add("@name", product.Name);
                parameter.Add("@description", product.Description);
                parameter.Add("@content", product.Content);
                parameter.Add("@price", product.Price);
                parameter.Add("includedVat", product.IncludedVat);
                parameter.Add("@categoryId", product.CategoryId);
                parameter.Add("@id", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
                var result = await conn.ExecuteAsync("Create_Product", parameter, null, null, System.Data.CommandType.StoredProcedure);
                int newId = parameter.Get<int>("@id");
                return newId;
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                await conn.ExecuteAsync("Delete_Product", parameters, null, null, System.Data.CommandType.StoredProcedure);
            }
        }

        [HttpGet("Paging", Name = "paged")]
        public async Task<PagedResult<Products>> GetPagedProduct(string keyword, int categoryId, int pageIndex, int pageSize)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                var parameters = new DynamicParameters();
                parameters.Add("@keyword", keyword);
                parameters.Add("@categoryId", categoryId);
                parameters.Add("@pageIndex", pageIndex);
                parameters.Add("@pageSize", pageSize);
                parameters.Add("@totalRow", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
                var result = await conn.QueryAsync<Products>("Get_Product_AllPaging", parameters, null, null, System.Data.CommandType.StoredProcedure);
                int totalRow = parameters.Get<int>("@totalRow");
                var pageResult = new PagedResult<Products>()
                {
                    Items = result.ToList(),
                    TotalRow = totalRow,
                    PageIndex = pageIndex,
                    PageSize = pageSize
                };
                return pageResult;
            }
        }
    }
}
