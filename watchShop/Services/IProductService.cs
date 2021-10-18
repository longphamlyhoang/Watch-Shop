using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchShop.Entities;
using watchShop.Models.Shop;

namespace watchShop.Services
{
    public interface IProductService
    {
        List<Product> GetProductByCategoryId(int CategoryId);
        bool Create(Product model);
        bool Edit(Product model);
        Product Get(int productId);
        bool Remove(int productId);

    }
}
