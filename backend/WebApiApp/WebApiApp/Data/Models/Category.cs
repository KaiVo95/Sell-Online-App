using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiApp.Data.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public long CategoryId { get; set; }
        public string Name { get; set; }
        public long ParentId { get; set; }
        public int SortOrder { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
