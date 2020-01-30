using System;
using System.Collections.Generic;

namespace TeduShopData.Models
{
    public partial class AppUsers
    {
        public AppUsers()
        {
            AnnouncementUsers = new HashSet<AnnouncementUsers>();
            Announcements = new HashSet<Announcements>();
            AppUserClaims = new HashSet<AppUserClaims>();
            AppUserLogins = new HashSet<AppUserLogins>();
            AppUserRoles = new HashSet<AppUserRoles>();
            Orders = new HashSet<Orders>();
        }

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string NormalizedUserName { get; set; } 
        public string Address { get; set; }
        public string Avatar { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool? Status { get; set; }
        public bool? Gender { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string NormalizedEmail { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<AnnouncementUsers> AnnouncementUsers { get; set; }
        public virtual ICollection<Announcements> Announcements { get; set; }
        public virtual ICollection<AppUserClaims> AppUserClaims { get; set; }
        public virtual ICollection<AppUserLogins> AppUserLogins { get; set; }
        public virtual ICollection<AppUserRoles> AppUserRoles { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
