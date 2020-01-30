using System;
using System.Collections.Generic;
using System.Text;

namespace TeduShopData.Dtos
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalRow { set; get; }
    }
}
