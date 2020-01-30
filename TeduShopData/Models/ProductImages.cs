using System;
using System.Collections.Generic;

namespace TeduShopData.Models
{
    public partial class ProductImages
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Path { get; set; }
        public string Caption { get; set; }

        public virtual Products Product { get; set; }
    }
}
