using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TeduShopData.Models;

namespace TeduShopAPIDapperCore.Data
{
    public class RoleStore : IRoleStore<AppRoles>
    {
        private readonly string _connectionString;

        public RoleStore(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DbConnectionString");
        }
        public async Task<IdentityResult> CreateAsync(AppRoles role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(cancellationToken);
                role.Id = Guid.NewGuid();
                await connection.ExecuteAsync($@"INSERT INTO [AppRoles] ([Id], [Name],[Description], [NormalizedName])
                    VALUES (@{nameof(AppRoles.Id)},@{nameof(AppRoles.Name)},@{nameof(AppRoles.Description)}, @{nameof(AppRoles.NormalizedName)});", role);
            }

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(AppRoles role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync(cancellationToken);
                await conn.ExecuteAsync($@"DELETE FROM [AppRoles] WHERE [id] = @{nameof(AppRoles.Id)}", role);
            }
            return IdentityResult.Success;
        }

        public void Dispose()
        {
            
        }

        public async Task<AppRoles> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync(cancellationToken);
                var result = await conn.QuerySingleAsync<AppRoles>($@"SELECT * FROM [AppRoles] WHERE [id]= @{nameof(roleId)}", new { roleId });
                return result;
            }
        }

        public async Task<AppRoles> FindByNameAsync(string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(cancellationToken);
                return await connection.QuerySingleOrDefaultAsync<AppRoles>($@"SELECT * FROM [AppRoles]
                    WHERE [NormalizedName] = @{nameof(normalizedName)}", new { normalizedName });
            }
        }

        public Task<string> GetNormalizedRoleNameAsync(AppRoles role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleIdAsync(AppRoles role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Id.ToString());
        }

        public Task<string> GetRoleNameAsync(AppRoles role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task SetNormalizedRoleNameAsync(AppRoles role, string normalizedName, CancellationToken cancellationToken)
        {
            role.NormalizedName = normalizedName;
            return Task.FromResult(0);
        }

        public Task SetRoleNameAsync(AppRoles role, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> UpdateAsync(AppRoles role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync(cancellationToken);
                await conn.ExecuteAsync($@"UPDATE [AppRoles] SET
                    [name] = @{nameof(AppRoles.Name)},
                    [Description] = @{nameof(AppRoles.Description)}
                    WHERE [id] = @{nameof(AppRoles.Id)}", role);
            }
            return IdentityResult.Success;
        }
    }
}
