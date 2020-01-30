using System;
using System.Collections.Generic;

namespace TeduShopData.Models
{
    public partial class Feedbacks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
