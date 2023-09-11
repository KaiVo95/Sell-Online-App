namespace WebApiApp.Models
{
    public class CategoryVM
    {
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public long ParentId { get; set; }
        public int SortOrder { get; set; }
    }
}
