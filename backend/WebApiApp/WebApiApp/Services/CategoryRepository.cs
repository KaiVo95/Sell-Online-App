using System.Collections.Generic;
using System.Linq;
using WebApiApp.Data.Models;
using WebApiApp.Models;

namespace WebApiApp.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SellOnlineApiAppContext _context;

        public CategoryRepository(SellOnlineApiAppContext context)
        {
            _context = context;
        }
        public List<CategoryVM> GetAll()
        {
            var categories = _context.Categories.Select(ca => new CategoryVM
            {
                CategoryId = ca.CategoryId,
                CategoryName = ca.Name,
                ParentId = ca.ParentId,
                SortOrder = ca.SortOrder
            }).OrderBy(ca => ca.SortOrder);
            return categories.ToList();
        }

        public CategoryVM GetById(long id)
        {
            var category = _context.Categories.SingleOrDefault(ca => ca.CategoryId == id);
            if (category != null)
            {
                return new CategoryVM
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.Name,
                    ParentId = category.ParentId,
                    SortOrder = category.SortOrder
                };
            }
            return null;
        }

        public CategoryVM Add(CategoryModel category)
        {
            var _category = new Category
            {
                Name = category.CategoryName,
                ParentId = category.ParentId,
                SortOrder = category.SortOrder
            };
            _context.Add(_category);
            _context.SaveChanges();

            return new CategoryVM
            {
                CategoryId = _category.CategoryId,
                CategoryName = _category.Name,
                ParentId = _category.ParentId,
                SortOrder = _category.SortOrder
            };
        }

        public void Update(long categoryId, CategoryModel category)
        {
            var _category = _context.Categories.SingleOrDefault(lo => lo.CategoryId == categoryId);
            if (_category != null)
            {
                _category.Name = category.CategoryName;
                _category.ParentId = category.ParentId;
                _category.SortOrder = category.SortOrder;
                _context.SaveChanges();
            }
        }

        public void Delete(long id)
        {
            var category = _context.Categories.SingleOrDefault(lo => lo.CategoryId == id);
            if (category != null)
            {
                _context.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}
