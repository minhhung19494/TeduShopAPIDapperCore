using System;
using System.Collections.Generic;

namespace TeduShopData.Models
{
    public partial class AnnouncementUsers
    {
        public int AnnouncementId { get; set; }
        public Guid UserId { get; set; }
        public bool HasRead { get; set; }

        public virtual Announcements Announcement { get; set; }
        public virtual AppUsers User { get; set; }
    }
}
