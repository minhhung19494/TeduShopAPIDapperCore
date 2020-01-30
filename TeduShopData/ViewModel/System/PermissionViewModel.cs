using System;
using System.Collections.Generic;
using System.Text;

namespace TeduShopData.ViewModel.System
{
    public class PermissionViewModel
    {
        public int ID { get; set; }
        public Guid RoleId { get; set; }
        public string FunctionId { get; set; }
        public int ActionId { get; set; }
        public ApplicationRoleViewModel AppRole { get; set; }
        public FunctionViewModel Function { get; set; }
    }
}
