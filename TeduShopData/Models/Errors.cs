using System;
using System.Collections.Generic;

namespace TeduShopData.Models
{
    public partial class Errors
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
