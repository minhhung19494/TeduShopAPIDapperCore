using System;
using System.Collections.Generic;

namespace TeduShopData.Models
{
    public partial class Announcements
    {
        public Announcements()
        {
            AnnouncementUsers = new HashSet<AnnouncementUsers>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public Guid UserId { get; set; }

        public virtual AppUsers User { get; set; }
        public virtual ICollection<AnnouncementUsers> AnnouncementUsers { get; set; }
    }
}
