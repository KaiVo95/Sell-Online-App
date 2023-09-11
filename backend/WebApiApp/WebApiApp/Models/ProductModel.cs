namespace WebApiApp.Models
{
    public class ProductModel
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Content { get; set; }
        public int Discount { get; set; }
        public string ImageLink { get; set; }
        public string ImageList { get; set; }
    }
}
