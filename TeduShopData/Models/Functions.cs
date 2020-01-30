using System;
using System.Collections.Generic;

namespace TeduShopData.Models
{
    public partial class Functions
    {
        public Functions()
        {
            InverseParent = new HashSet<Functions>();
            Permissions = new HashSet<Permissions>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int DisplayOrder { get; set; }
        public string ParentId { get; set; }
        public bool Status { get; set; }
        public string IconCss { get; set; }

        public virtual Functions Parent { get; set; }
        public virtual ICollection<Functions> InverseParent { get; set; }
        public virtual ICollection<Permissions> Permissions { get; set; }
        public virtual ICollection<ActionsInFunction> ActionsInFunction { get; set; }
    }
}
