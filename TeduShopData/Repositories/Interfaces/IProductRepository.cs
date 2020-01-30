using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeduShopData.Dtos;
using TeduShopData.Models;
using TeduShopData.ViewModel.Product;

namespace TeduShopData.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Products>> GetAllAsync();
        Task<Products> GetByIdAsync(int Id);
        Task<PagedResult<Products>> GetPaging(string keyword, int categoryId, int pageIndex, int pageSize);
        Task<int> Create(Products product);
        Task Update(int id, Products product);
        Task Delete(int id);
        Task<List<ProductsAttributeViewModel>> GetAttributes(int id);
        Task<PagedResult<Products>> SearchByAttributes(string keyword, int categoryId, string size, int pageIndex, int pageSize);
    }
}
