using System;
using System.Collections.Generic;

namespace TeduShopData.Models
{
    public partial class PostTags
    {
        public int PostId { get; set; }
        public string TagId { get; set; }

        public virtual Posts Post { get; set; }
        public virtual Tags Tag { get; set; }
    }
}
