using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeduShopData.ViewModel.System;

namespace TeduShopData.Repositories.Interfaces
{
    public interface IAttributeRepository
    {
        Task<List<AttributeViewModel>> GetAll();

        Task<AttributeViewModel> GetById(int id);

        Task Add(AttributeViewModel attribute);

        Task Update(int id, AttributeViewModel attribute);

        Task Delete(int id);
    }
}
