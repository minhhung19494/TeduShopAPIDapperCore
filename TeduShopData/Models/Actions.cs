using System;
using System.Collections.Generic;
using System.Text;

namespace TeduShopData.Models
{
    public partial class Actions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { set; get; }
        public virtual ICollection<Permissions> Permissions { get; set; }
        public virtual ICollection<ActionsInFunction> ActionsInFunction { get; set; }
    }
}
