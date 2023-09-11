using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiApp.Data.Models;
using WebApiApp.Models;

namespace WebApiApp.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly SellOnlineApiAppContext _context;
        public static int PAGE_SIZE { get; set; } = 5;

        public ProductRepository(SellOnlineApiAppContext context)
        {
            _context = context;
        }
        public List<ProductVM> GetAll(string search, decimal? from, decimal? to, string sortBy, int page = 1)
        {
            var allProducts = _context.Products.Include(p => p.Category).AsQueryable();

            #region Filtering
            if (!string.IsNullOrEmpty(search))
            {
                allProducts = allProducts.Where(p => p.Name.Contains(search));
            }
            if (from.HasValue)
            {
                allProducts = allProducts.Where(p => p.Price >= from);
            }
            if (to.HasValue)
            {
                allProducts = allProducts.Where(p => p.Price <= to);
            }
            #endregion


            #region Sorting
            //Default sort by Name (TenHh)
            allProducts = allProducts.OrderBy(p => p.Name);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "tenhh_desc": allProducts = allProducts.OrderByDescending(p => p.Name); break;
                    case "price_asc": allProducts = allProducts.OrderBy(p => p.Price); break;
                    case "price_desc": allProducts = allProducts.OrderByDescending(p => p.Price); break;
                }
            }
            #endregion

            var result = PaginatedList<Product>.Create(allProducts, page, PAGE_SIZE);

            return result.Select(p => new ProductVM
            {
                ProductId = p.ProductId,
                CategoryId = p.Category?.CategoryId ?? 0,
                Name = p.Name,
                Price = p.Price,
                Content = p.Content,
                Discount = p.Discount,
                ImageLink = p.ImageLink,
                ImageList = p.ImageList,
                View = p.View
            }).ToList();
        }

        public ProductVM GetById(long productId)
        {
            var product = _context.Products.Include(x => x.Category).SingleOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                return new ProductVM
                {
                    ProductId = product.ProductId,
                    CategoryId = product.Category?.CategoryId ?? 0,
                    Name = product.Name,
                    Price = product.Price,
                    Content = product.Content,
                    Discount = product.Discount,
                    ImageLink = product.ImageLink,
                    ImageList = product.ImageList,
                    View = product.View
                };
            }
            return null;
        }

        public ProductVM Add(ProductModel product)
        {
            var _product = new Product
            {
                CategoryId = product.CategoryId,
                Name = product.Name,
                Price = product.Price,
                Content = product.Content,
                Discount = product.Discount,
                ImageLink = product.ImageLink,
                ImageList = product.ImageList,
                View = 0,
                Created = DateTimeOffset.UtcNow
            };
            _context.Add(_product);
            _context.SaveChanges();

            return new ProductVM
            {
                ProductId = _product.ProductId,
                CategoryId = _product.Category?.CategoryId ?? 0,
                Name = _product.Name,
                Price = _product.Price,
                Content = _product.Content,
                Discount = _product.Discount,
                ImageLink = _product.ImageLink,
                ImageList = _product.ImageList,
                View = _product.View
            };
        }

        public void Update(long productId, ProductModel product)
        {
            var _product = _context.Products.SingleOrDefault(lo => lo.ProductId == productId);
            if (_product != null)
            {
                _product.CategoryId = product.CategoryId;
                _product.Name = product.Name;
                _product.Price = product.Price;
                _product.Content = product.Content;
                _product.Discount = product.Discount;
                _product.ImageLink = product.ImageLink;
                _product.ImageList = product.ImageList;
                _context.SaveChanges();
            }
        }

        public void Delete(long productId)
        {
            var product = _context.Products.SingleOrDefault(lo => lo.ProductId == productId);
            if (product != null)
            {
                _context.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
