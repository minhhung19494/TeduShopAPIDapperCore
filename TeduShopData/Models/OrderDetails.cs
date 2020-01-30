using System;
using System.Collections.Generic;

namespace TeduShopData.Models
{
    public partial class OrderDetails
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }

        public virtual Colors Color { get; set; }
        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
        public virtual Sizes Size { get; set; }
    }
}
