using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShopData.Dtos;
using TeduShopData.Models;
using TeduShopData.Repositories.Interfaces;
using TeduShopData.ViewModel.Product;

namespace TeduShopData.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DbConnectionString");
        }
        public async Task<int> Create(Products product)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                var paramaters = new DynamicParameters();
                paramaters.Add("@name", product.Name);
                paramaters.Add("@description", product.Description);
                paramaters.Add("@content", product.Content);
                paramaters.Add("@metaDescription", product.MetaDescription);
                paramaters.Add("@alias", product.Alias);
                paramaters.Add("@metaKeyword", product.MetaKeyword);
                paramaters.Add("@price", product.Price);
                paramaters.Add("@status", product.Status);
                paramaters.Add("@thumbnailImage", product.ThumbnailImage);
                paramaters.Add("@categoryId", product.CategoryId);
                paramaters.Add("@includedVAT", product.IncludedVat);
                paramaters.Add("@tags", product.Tags);
                paramaters.Add("@id", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
                var result = await conn.ExecuteAsync("Create_Product", paramaters, null, null, System.Data.CommandType.StoredProcedure);

                int newId = paramaters.Get<int>("@id");
                return newId;
            }
        }

        public async Task Delete(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                var paramaters = new DynamicParameters();
                paramaters.Add("@id", id);
                await conn.ExecuteAsync("Delete_Product_ById", paramaters, null, null, System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Products>> GetAllAsync()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                var paramaters = new DynamicParameters();

                var result = await conn.QueryAsync<Products>("Get_Product_All", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<List<ProductsAttributeViewModel>> GetAttributes(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                var paramaters = new DynamicParameters();
                paramaters.Add("@id", id);

                var result = await conn.QueryAsync<ProductsAttributeViewModel>("Get_Product_Attributes", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<Products> GetByIdAsync(int Id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                var paramaters = new DynamicParameters();
                paramaters.Add("@id", Id);

                var result = await conn.QueryAsync<Products>("Get_Product_ById", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                return result.Single();
            }
        }

        public async Task<PagedResult<Products>> GetPaging(string keyword, int categoryId, int pageIndex, int pageSize)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                var paramaters = new DynamicParameters();
                paramaters.Add("@keyword", keyword);
                paramaters.Add("@pageIndex", pageIndex);
                paramaters.Add("@pageSize", pageSize);
                paramaters.Add("@categoryId", categoryId);
                paramaters.Add("@totalRow", dbType:System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                var result = await conn.QueryAsync<Products>("Get_Product_AllPaging", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                int totalRow = paramaters.Get<int>("@totalRow");
                var pagedResult = new PagedResult<Products>()
                {
                    Items = result.ToList(),
                    TotalRow = totalRow,
                    PageIndex = pageIndex,
                    PageSize = pageSize
                };
                return pagedResult;
            }
        }

        public async Task<PagedResult<Products>> SearchByAttributes(string keyword, int categoryId, string size, int pageIndex, int pageSize)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                var paramaters = new DynamicParameters();
                paramaters.Add("@keyword", keyword);
                paramaters.Add("@categoryId", categoryId);
                paramaters.Add("@pageIndex", pageIndex);
                paramaters.Add("@pageSize", pageSize);
                paramaters.Add("@size", size);

                paramaters.Add("@totalRow", dbType: System.Data.DbType.Int32,
                    direction: System.Data.ParameterDirection.Output);

                var result = await conn.QueryAsync<Products>("[Search_Product_ByAttributes]",
                    paramaters, null, null, System.Data.CommandType.StoredProcedure);

                int totalRow = paramaters.Get<int>("@totalRow");

                var pagedResult = new PagedResult<Products>()
                {
                    Items = result.ToList(),
                    TotalRow = totalRow,
                    PageIndex = pageIndex,
                    PageSize = pageSize
                };
                return pagedResult;
            }
        }

        public async Task Update(int id, Products product)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                var paramaters = new DynamicParameters();
                paramaters.Add("@id", id);
                paramaters.Add("@name", product.Name);
                paramaters.Add("@description", product.Description);
                paramaters.Add("@content", product.Content);
                paramaters.Add("@metaDescription", product.MetaDescription);
                paramaters.Add("@alias", product.Alias);
                paramaters.Add("@metaKeyword", product.MetaKeyword);
                paramaters.Add("@price", product.Price);
                paramaters.Add("@status", product.Status);
                paramaters.Add("@thumbnailImage", product.ThumbnailImage);
                paramaters.Add("@categoryId", product.CategoryId);
                paramaters.Add("@includedVAT", product.IncludedVat);
                paramaters.Add("@tags", product.Tags);
                await conn.ExecuteAsync("Update_Product", paramaters, null, null, System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
