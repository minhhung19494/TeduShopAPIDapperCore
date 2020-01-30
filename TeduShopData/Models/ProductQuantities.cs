using System;
using System.Collections.Generic;

namespace TeduShopData.Models
{
    public partial class ProductQuantities
    {
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int Quantity { get; set; }

        public virtual Colors Color { get; set; }
        public virtual Products Product { get; set; }
        public virtual Sizes Size { get; set; }
    }
}
