using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiApp.Data.Models
{
    public partial class Admin
    {
        public long AdminId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
