using System;
using System.Collections.Generic;

namespace TeduShopData.Models
{
    public partial class Colors
    {
        public Colors()
        {
            OrderDetails = new HashSet<OrderDetails>();
            ProductQuantities = new HashSet<ProductQuantities>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<ProductQuantities> ProductQuantities { get; set; }
    }
}
