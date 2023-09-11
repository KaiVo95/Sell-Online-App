using System;

namespace WebApiApp.Models
{
    public class ProductVM
    {
        public long ProductId { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Content { get; set; }
        public int Discount { get; set; }
        public string ImageLink { get; set; }
        public string ImageList { get; set; }
        public DateTimeOffset Created { get; set; }
        public int View { get; set; }

    }
}
