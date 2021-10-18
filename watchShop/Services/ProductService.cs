using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchShop.Context;
using watchShop.Entities;
using watchShop.Models.Shop;

namespace watchShop.Services
{
    public class ProductService : IProductService
    {
        private readonly WatchShopDBContext context;

        public ProductService(WatchShopDBContext context)
        {
            this.context = context;
        }

        public bool Create(Product model)
        {
            try
            {
                context.Add(model);
                return context.SaveChanges() > 0;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Edit(Product product)
        {
            try
            {
                context.Attach(product);
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Product Get(int productId)
        {
            return context.products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == productId);
        }

        public List<Product> GetProductByCategoryId(int CategoryId)
        {
            return context.products.Include(p => p.Category).Where(p => p.CategoryId == CategoryId).ToList();
        }

        public bool Remove(int productId)
        {
            try
            {
                var product = Get(productId);
                context.Remove(product);
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
