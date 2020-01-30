using System;
using System.Collections.Generic;

namespace TeduShopData.Models
{
    public partial class AppUserRoles
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public Guid AppUserId { get; set; }
        public Guid IdentityRoleId { get; set; }

        public virtual AppUsers AppUser { get; set; }
        public virtual AppRoles IdentityRole { get; set; }
    }
}
