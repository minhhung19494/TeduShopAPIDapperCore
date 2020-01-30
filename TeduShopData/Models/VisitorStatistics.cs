using System;
using System.Collections.Generic;

namespace TeduShopData.Models
{
    public partial class VisitorStatistics
    {
        public Guid Id { get; set; }
        public DateTime VisitedDate { get; set; }
        public string Ipaddress { get; set; }
    }
}
