using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeduShopData.ViewModel.System
{
    public class ApplicationRoleViewModel
    {
        public Guid Id { set; get; }

        [Required(ErrorMessage = "Bạn phải nhập tên")]
        public string Name { set; get; }

        public string Description { set; get; }
    }
}
