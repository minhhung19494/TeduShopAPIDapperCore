using System;
using System.Collections.Generic;

namespace TeduShopData.Models
{
    public partial class Permissions
    {
        public int Id { get; set; }
        public Guid RoleId { get; set; }
        public string FunctionId { get; set; }
        public int ActionId { get; set; }

        public virtual Functions Function { get; set; }
        public virtual AppRoles Role { get; set; }
        public virtual Actions Action { get; set; }
    }
}
