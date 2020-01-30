using System;
using System.Collections.Generic;
using System.Text;

namespace TeduShopData.Dtos

{
    public class LoginViewModel
    {
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool RememberMe { get; set; }
    }
}
