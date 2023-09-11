using System.ComponentModel.DataAnnotations;

namespace WebApiApp.Models
{
    public class CategoryModel
    {
        public string CategoryName { get; set; }
        public long ParentId { get; set; }
        public int SortOrder { get; set; }
    }
}
