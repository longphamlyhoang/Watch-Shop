using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchShop.Context;
using watchShop.Entities;
using watchShop.Models.Category;

namespace watchShop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly WatchShopDBContext context;
        public CategoryService(WatchShopDBContext context)
        {
            this.context = context;
        }
        public bool ChangStatus(int categoryId)
        {
            try
            {
                var category = Get(categoryId);
                category.Status = !category.Status;
                context.Attach(category);
                context.Entry(category).State = EntityState.Modified;
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Create(Create create)
        {
            try
            {
                var category = new Category()
                {
                    CategoryName = create.CategoryName,
                    Description = create.Description,
                    Picture = create.Picture,
                    Status = create.Status
                };
                context.Add(category);
                return context.SaveChanges() > 0;
            }
            catch(Exception EX)
            {
                return false;
            }
        }

        public bool Edit(Edit edit)
        {
            try
            {
                var category = Get(edit.CategoryId);
                category.CategoryName = edit.CategoryName;
                category.Description = edit.Description;
                category.Picture = edit.Picture;
                category.CategoryId = edit.CategoryId;
                category.Status = edit.Status;
                return context.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Category Get(int CategoryId)
        {
            return context.categories.FirstOrDefault(c => c.CategoryId == CategoryId);
        }

        public List<Category> Gets()
        {
            return context.categories.Include(p => p.Products).ToList();
        }
    }
}
