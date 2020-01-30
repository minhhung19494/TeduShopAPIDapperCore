using System;
using System.Collections.Generic;
using System.Text;

namespace TeduShopData.ViewModel.Product
{
    public class ProductImageViewModel
    {
        public int ID { get; set; }

        public int ProductId { get; set; }

        public ProductViewModel Product { get; set; }

        public string Path { get; set; }

        public string Caption { get; set; }
    }
}
