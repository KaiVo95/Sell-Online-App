using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiApp.Data.Models
{
    public partial class Transaction
    {
        public Transaction()
        {
            Orders = new HashSet<Order>();
        }

        public long TransactionId { get; set; }
        public int Status { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public decimal Amount { get; set; }
        public string Payment { get; set; }
        public string PaymentInfo { get; set; }
        public string Security { get; set; }
        public DateTimeOffset Created { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
