using System;
using System.Collections.Generic;
using System.Text;
using TeduShopData.ViewModel.Common;

namespace TeduShopData.ViewModel
{
    public class AnnouncementViewModel
    {
        public AnnouncementViewModel()
        {
            AnnouncementUsers = new List<AnnouncementUserViewModel>();
        }
        public int ID { set; get; }

        public string Title { set; get; }

        public string Content { set; get; }

        public DateTime CreatedDate { get; set; }

        public string UserId { set; get; }

        public AppUserViewModel AppUser { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<AnnouncementUserViewModel> AnnouncementUsers { get; set; }
    }
}
