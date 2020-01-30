using System;
using System.Collections.Generic;

namespace TeduShopData.Models
{
    public partial class AppUserLogins
    {
        public string UserId { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public Guid AppUserId { get; set; }

        public virtual AppUsers AppUser { get; set; }
    }
}
