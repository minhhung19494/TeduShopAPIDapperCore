using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TeduShopData.Models;
using TeduShopData.ViewModel.System;

namespace TeduShopAPIDapperCore.Extensions
{
    public static class IdentityExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            var claim = ((ClaimsIdentity)claimsPrincipal.Identity).Claims.Single(x => x.Type == ClaimTypes.NameIdentifier);
            return Guid.Parse(claim.Value);
        }
        public static void UpdateApplicationRole(this AppRoles appRole, ApplicationRoleViewModel appRoleViewModel, string action = "add")
        {
            if (action == "update")
                appRole.Id = appRoleViewModel.Id;
            else
                appRole.Id = Guid.NewGuid();
            appRole.Name = appRoleViewModel.Name;
            appRole.Description = appRoleViewModel.Description;
        }
    }
}
