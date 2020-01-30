using System;
using System.Collections.Generic;
using System.Text;
using TeduShopData.ViewModel.Product;

namespace TeduShopData.ViewModel.Common
{
    public class ShoppingCartViewModel
    {
        public int ProductId { set; get; }
        public ProductViewModel Product { set; get; }
        public int Quantity { set; get; }
    }
}
