using System;
using System.Collections.Generic;
using System.Text;
using TeduShopData.ViewModel.Common;

namespace TeduShopData.ViewModel.Product
{
    public class ProductTagViewModel
    {
        public int ProductID { set; get; }

        public string TagID { set; get; }

        public virtual ProductViewModel Post { set; get; }

        public virtual TagViewModel Tag { set; get; }
    }
}
