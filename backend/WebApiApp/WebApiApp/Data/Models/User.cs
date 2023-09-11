using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiApp.Data.Models
{
    public partial class User
    {
        public User()
        {
            RefreshTokens = new HashSet<RefreshToken>();
            Transactions = new HashSet<Transaction>();
        }

        public long UserId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTimeOffset Created { get; set; }

        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
