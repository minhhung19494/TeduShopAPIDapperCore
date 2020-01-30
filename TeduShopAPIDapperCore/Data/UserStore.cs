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
    public class UserStore : IUserStore<AppUsers>, IUserEmailStore<AppUsers>, IUserPhoneNumberStore<AppUsers>, IUserTwoFactorStore<AppUsers>,
        IUserPasswordStore<AppUsers>, IUserRoleStore<AppUsers>
    {
        private readonly string _connectionString;
        public UserStore(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DbConnectionString");
        }
        public async Task AddToRoleAsync(AppUsers user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync(cancellationToken);
                var roleId = await conn.QuerySingleAsync<Guid?>($@"SELECT [Id] FROM [AppRoles] WHERE [Name]=@{nameof(roleName)}", new { roleName });
                if (!roleId.HasValue)
                {
                    var newRoleId = Guid.NewGuid();
                    await conn.ExecuteAsync($"INSERT INTO [AppRoles] ([Id], [Name]) VALUES (@{nameof(roleId)}, @{nameof(roleName)})", new { roleId, roleName });
                }
                await conn.ExecuteAsync($"IF NOT EXISTS(SELECT 1 FROM [AppUserRoles] WHERE [UserId] = @userId and [RoleId]=@{nameof(roleId)}) " +
                    $"INSERT INTO [AppUserRoles] ([UserId], [RoleId]) VALUES (@userId, @{nameof(roleId)})", new { userId = user.Id, roleId });
            }

        }

        public async Task<IdentityResult> CreateAsync(AppUsers user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync(cancellationToken);
                user.Id = Guid.NewGuid();
                await conn.ExecuteAsync($@"INSERT INTO [AppUsers] ([Id], [FullName], [Address], [Birthday], [Gender], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [NormalizedUserName], [NormalizedEmail] ) VALUES(@{nameof(AppUsers.Id)}, @{nameof(AppUsers.FullName)}, @{nameof(AppUsers.Address)}, @{nameof(AppUsers.BirthDay)}, @{nameof(AppUsers.Gender)}, @{nameof(AppUsers.Email)}, @{nameof(AppUsers.EmailConfirmed)}, @{nameof(AppUsers.PasswordHash)}, @{nameof(AppUsers.SecurityStamp)}, @{nameof(AppUsers.PhoneNumber)}, @{nameof(AppUsers.PhoneNumberConfirmed)}, @{nameof(AppUsers.TwoFactorEnabled)}, @{nameof(AppUsers.LockoutEndDateUtc)}, @{nameof(AppUsers.LockoutEnabled)}, @{nameof(AppUsers.AccessFailedCount)}, @{nameof(AppUsers.UserName)}, @{nameof(AppUsers.NormalizedUserName)}, @{nameof(AppUsers.NormalizedEmail)}) ", user);
            }
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(AppUsers user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync(cancellationToken);
                await conn.ExecuteAsync($@"DELETE FROM [AppUsers] WHERE [Id] = @{nameof(AppUsers.Id)}", user);
            }
            return IdentityResult.Success;
        }

        public void Dispose()
        {
            
        }

        public async Task<AppUsers> FindByEmailAsync(string Email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync(cancellationToken);
                return await conn.QuerySingleAsync<AppUsers>($@"SELECT * FROM [AppUsers] WHERE [Email] = @{nameof(Email)}", new { Email });
            }
        }

        public async Task<AppUsers> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync(cancellationToken);
                return await conn.QuerySingleAsync<AppUsers>($@"SELECT * FROM [AppUsers] WHERE [Id] = @{nameof(userId)}", new { userId });
            }
        }

        public async Task<AppUsers> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync(cancellationToken);
                return await conn.QuerySingleOrDefaultAsync<AppUsers>($@"SELECT * FROM [AppUsers] WHERE [NormalizedUserName] = @{nameof(normalizedUserName)}", new { normalizedUserName });
            }
        }

        public Task<string> GetEmailAsync(AppUsers user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(AppUsers user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedEmailAsync(AppUsers user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedUserName);
        }

        public Task<string> GetNormalizedUserNameAsync(AppUsers user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(AppUsers user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<string> GetPhoneNumberAsync(AppUsers user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(AppUsers user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<string>> GetRolesAsync(AppUsers user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync(cancellationToken);
                var result = await conn.QueryAsync<string>($"SELECT [Name] FROM [AppUserRoles] a INNER JOIN [AppRoles] r ON a.RoleId=r.Id WHERE [UserId]= @userId", new { userId = user.Id });
                return result.ToList();
            }
        }

        public Task<bool> GetTwoFactorEnabledAsync(AppUsers user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.TwoFactorEnabled);
        }

        public Task<string> GetUserIdAsync(AppUsers user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(AppUsers user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public async Task<IList<AppUsers>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync(cancellationToken);
                var result = await conn.QueryAsync<AppUsers>($"SELECT u.* FROM [AppUsers] u INNER JOIN [AppUserRoles] ur ON ur.[UserId]=u.[id] INNER JOIN [AppRoles] r ON r.[Id]=ur.[RoleId] WHERE r.[Name] = @{nameof(roleName)} ", new { roleName });
                return result.ToList();
            }
        }

        public Task<bool> HasPasswordAsync(AppUsers user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsInRoleAsync(AppUsers user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync(cancellationToken);
                var roleId = await conn.ExecuteScalarAsync<int?>($@"SELECT [Id] FROM [AppRoles] WHERE [Name]=@{nameof(roleName)}", new { roleName });
                if (roleId == default(int)) return false;
                var matchingRoles = await conn.ExecuteScalarAsync<int>($"SELECT COUNT(*) FROM [AppUserRoles] WHERE [RoleId]=@{nameof(roleId)}", new { roleId });
                return matchingRoles > 0;
            }
        }

        public async Task RemoveFromRoleAsync(AppUsers user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync(cancellationToken);
                var roleId = await conn.ExecuteScalarAsync<string>($@"SELECT [Id] FROM [AppRoles] WHERE [Name]=@{nameof(roleName)}", new { roleName });
                if (!string.IsNullOrEmpty(roleId))
                {
                    await conn.ExecuteAsync($"DELETE [AppUserRoles] WHERE [UserId] = @userId AND [RoleId]=@{nameof(roleId)}", new { userId = user.Id, roleId });
                }

            }
        }

        public Task SetEmailAsync(AppUsers user, string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(AppUsers user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedEmailAsync(AppUsers user, string normalizedEmail, CancellationToken cancellationToken)
        {
            user.NormalizedEmail = normalizedEmail;
            return Task.FromResult(0);
        }

        public Task SetNormalizedUserNameAsync(AppUsers user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedUserName = normalizedName;
            return Task.FromResult(0);
        }

        public Task SetPasswordHashAsync(AppUsers user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task SetPhoneNumberAsync(AppUsers user, string phoneNumber, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPhoneNumberConfirmedAsync(AppUsers user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetTwoFactorEnabledAsync(AppUsers user, bool enabled, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(AppUsers user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> UpdateAsync(AppUsers user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync(cancellationToken);
                await conn.ExecuteAsync($@"UPDATE [AppUsers] SET 
                    [FullName] =  @{nameof(AppUsers.FullName)}, 
                    [Address] = @{nameof(AppUsers.Address)},
                    [Birthday] = @{nameof(AppUsers.BirthDay)},
                    [Gender] = @{nameof(AppUsers.Gender)}, 
                    [Email] = @{nameof(AppUsers.Email)},
                    [EmailConfirmed] = @{nameof(AppUsers.EmailConfirmed)},
                    [PasswordHash]=  @{nameof(AppUsers.PasswordHash)}, 
                    [PhoneNumber] =  @{nameof(AppUsers.PhoneNumber)}, 
                    [PhoneNumberConfirmed] = @{nameof(AppUsers.PhoneNumberConfirmed)},
                    [UserName] = @{nameof(AppUsers.UserName)})", user);
            }
            return IdentityResult.Success;
        }
    }
}
