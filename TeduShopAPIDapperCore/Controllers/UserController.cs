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
using TeduShopAPIDapperCore.Filters;
using TeduShopData.Dtos;
using TeduShopData.Models;

namespace TeduShopAPIDapperCore.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUsers> _userManager;
        private readonly string _connectionString;

        public UserController(UserManager<AppUsers> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _connectionString = configuration.GetConnectionString("DbConnectionString");
        }
        // GET: api/Role
        [HttpGet]
        [ClaimRequirement(FunctionCode.SYSTEM_USER, ActionCode.VIEW)]
        public async Task<IActionResult> Get()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    await conn.OpenAsync();

                var paramaters = new DynamicParameters();
                var result = await conn.QueryAsync<AppUsers>("Get_User_All", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                return Ok(result);
            }
        }
        // GET: api/Role/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _userManager.FindByIdAsync(id));
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

                var result = await conn.QueryAsync<AppUsers>("Get_User_AllPaging", paramaters, null, null, System.Data.CommandType.StoredProcedure);

                int totalRow = paramaters.Get<int>("@totalRow");

                var pagedResult = new PagedResult<AppUsers>()
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
        [ClaimRequirement(FunctionCode.SYSTEM_USER, ActionCode.CREATE)]
        public async Task<IActionResult> Post([FromBody] AppUsers user)
        {
            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
                return Ok();
            return BadRequest();
        }

        // PUT: api/Role/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([Required]Guid id, [FromBody] AppUsers user)
        {
            user.Id = id;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
                return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
                return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}/{roleName}/remove-roles")]
        public async Task<IActionResult> RemoveRoleToUser([Required]Guid id, [Required]string roleName)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var roleId = await connection.ExecuteScalarAsync<Guid?>("SELECT [Id] FROM [AppRoles] WHERE [NormalizedName] = @normalizedName", new { normalizedName = roleName.ToUpper() });
                if (roleId.HasValue)
                    await connection.ExecuteAsync($"DELETE FROM [AppUserRoles] WHERE [UserId] = @userId AND [RoleId] = @{nameof(roleId)}", new { userId = user.Id, roleId });
                return Ok();
            }
        }
        [HttpPut("{id}/{roleName}/assign-to-roles")]
        public async Task<IActionResult> AssignToRoles([Required]Guid id, [Required]string roleName)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var normalizedName = roleName.ToUpper();
                var roleId = await connection.ExecuteScalarAsync<Guid?>($"SELECT [Id] FROM [AppRoles] WHERE [NormalizedName] = @{nameof(normalizedName)}", new { normalizedName });
                if (!roleId.HasValue)
                {
                    roleId = Guid.NewGuid();
                    await connection.ExecuteAsync($"INSERT INTO [AppRoles]([Id],[Name], [NormalizedName]) VALUES(@{nameof(roleId)},@{nameof(roleName)}, @{nameof(normalizedName)})",
                       new { roleName, normalizedName });
                }
                await connection.ExecuteAsync($"IF NOT EXISTS(SELECT 1 FROM [AppUserRoles] WHERE [UserId] = @userId AND [RoleId] = @{nameof(roleId)}) " +
                    $"INSERT INTO [AppUserRoles]([UserId], [RoleId]) VALUES(@userId, @{nameof(roleId)})",
                    new { userId = user.Id, roleId });
                return Ok();
            }
        }
    }
}
