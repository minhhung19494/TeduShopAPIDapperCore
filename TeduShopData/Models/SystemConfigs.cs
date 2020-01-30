using System;
using System.Collections.Generic;

namespace TeduShopData.Models
{
    public partial class SystemConfigs
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ValueString { get; set; }
        public int? ValueInt { get; set; }
    }
}
