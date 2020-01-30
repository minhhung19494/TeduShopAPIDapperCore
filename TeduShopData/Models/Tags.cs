using System;
using System.Collections.Generic;

namespace TeduShopData.Models
{
    public partial class Tags
    {
        public Tags()
        {
            PostTags = new HashSet<PostTags>();
            ProductTags = new HashSet<ProductTags>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual ICollection<PostTags> PostTags { get; set; }
        public virtual ICollection<ProductTags> ProductTags { get; set; }
    }
}
