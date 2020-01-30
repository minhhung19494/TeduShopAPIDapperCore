using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeduShopData.Repositories.Interfaces;
using TeduShopData.ViewModel.System;

namespace TeduShopAPIDapperCore.Controllers
{
    [Route("api/[controller]")]
    public class AttributeController : ControllerBase
    {
        private readonly string _connectionString;
        private readonly IAttributeRepository _attributeRepository;

        public AttributeController(IConfiguration configuration, IAttributeRepository attributeRepository)
        {
            _connectionString = configuration.GetConnectionString("DbConnectionString");
            _attributeRepository = attributeRepository;
        }
        [HttpGet("{id}")]
        public async Task<AttributeViewModel> Get(int id)
        {
            return await _attributeRepository.GetById(id);
        }
        [HttpGet]
        public async Task<List<AttributeViewModel>> GetAll()
        {
            return await _attributeRepository.GetAll();
        }
        [HttpPost]
        public async Task AddAttribute([FromBody]AttributeViewModel attribute)
        {
            await _attributeRepository.Add(attribute);
        }
        [HttpPut("{id}")]
        public async Task Update(int id, [FromBody]AttributeViewModel attribute)
        {
            await _attributeRepository.Update(id, attribute);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _attributeRepository.Delete(id);
        }
    }
}

