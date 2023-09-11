using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiApp.Data.Models
{
    public partial class Order
    {
        public long OrderId { get; set; }
        public long TransactionId { get; set; }
        public long ProductId { get; set; }
        public int Qty { get; set; }
        public decimal Amount { get; set; }
        public string Data { get; set; }
        public int Status { get; set; }

        public virtual Product Product { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
