using System.Collections.Generic;
using WebApiApp.Models;

namespace WebApiApp.Services
{
    public interface ICategoryRepository
    {
        List<CategoryVM> GetAll();
        CategoryVM GetById(long categoryId);
        CategoryVM Add(CategoryModel category);
        void Update(long categoryId, CategoryModel category);
        void Delete(long categoryId);
    }
}
