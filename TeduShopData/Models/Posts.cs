using System;
using System.Collections.Generic;

namespace TeduShopData.Models
{
    public partial class Posts
    {
        public Posts()
        {
            PostTags = new HashSet<PostTags>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public bool Status { get; set; }

        public virtual PostCategories Category { get; set; }
        public virtual ICollection<PostTags> PostTags { get; set; }
    }
}
