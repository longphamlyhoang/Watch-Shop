using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchShop.Entities;
using watchShop.Models.Category;

namespace watchShop.Services
{
    public interface ICategoryService
    {
        List<Category> Gets();
        Category Get(int CategoryId);
        bool Create(Create create);
        bool Edit(Edit edit);
        bool ChangStatus(int categoryId);
    }
}
