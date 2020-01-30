using System;
using System.Collections.Generic;

namespace TeduShopData.Models
{
    public partial class AppUserClaims
    {
        public string UserId { get; set; }
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public Guid AppUserId { get; set; }

        public virtual AppUsers AppUser { get; set; }
    }
}
