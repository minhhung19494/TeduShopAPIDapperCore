using System;
using System.Collections.Generic;

namespace TeduShopData.Models
{
    public partial class AppRoles
    {
        public AppRoles()
        {
            AppUserRoles = new HashSet<AppUserRoles>();
            Permissions = new HashSet<Permissions>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string NormalizedName { get; set; }

        public virtual ICollection<AppUserRoles> AppUserRoles { get; set; }
        public virtual ICollection<Permissions> Permissions { get; set; }
    }
}
