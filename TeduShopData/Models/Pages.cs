using System;
using System.Collections.Generic;

namespace TeduShopData.Models
{
    public partial class Pages
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public bool Status { get; set; }
    }
}
