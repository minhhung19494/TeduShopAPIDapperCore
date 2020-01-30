using System;
using System.Collections.Generic;

namespace TeduShopData.Models
{
    public partial class ProductTags
    {
        public int ProductId { get; set; }
        public string TagId { get; set; }

        public virtual Products Product { get; set; }
        public virtual Tags Tag { get; set; }
    }
}
