using System.Collections.Generic;
using WebApiApp.Models;

namespace WebApiApp.Services
{
    public interface IProductRepository
    {
        List<ProductVM> GetAll(string search, decimal? from, decimal? to, string sortBy, int page = 1);
        ProductVM GetById(long productId);
        ProductVM Add(ProductModel product);
        void Update(long productId, ProductModel product);
        void Delete(long productId);
    }
}
