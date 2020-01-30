using System;
using System.Collections.Generic;
using System.Text;

namespace TeduShopData.Models
{
    public partial class ActionsInFunction
    {
        public int Id { get; set; }
        public int ActionId { get; set; }
        public string FunctionId { get; set; }
        public virtual Functions Functions { get; set; }
        public virtual Actions Actions { get; set; }
    }
}
