using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DataLayer;
using WebStore.Domain.Abstract;
using WebStore.Domain.Entities;

namespace WebStore.Repository
{
    public class SimpleCategoryRepository : ICategoryRepository, IDisposable
    {
        private WebStoreDbContext ctx = new WebStoreDbContext();

        public void AddNewCategory(Category category)
        {
            ctx.Categories.Add(category);
        }



        public ObservableCollection<Category> CategoriesInMemory()
        {
            if (ctx.Categories.Local.Count == 0)
            {
                GetGategories();
            }
            return ctx.Categories.Local;
        }

        public void DeleteCategory(int id)
        {
            var category = ctx.Categories.Find(id);
            ctx.Categories.Remove(category);
        }

        public void Dispose()
        {
            ctx.Dispose();
        }

        public Category GetCategoryById(int? id)
        {
            return ctx.Categories.Find(id);
        }



        public IQueryable<Category> GetGategories()
        {
            return ctx.Categories;
        }

        public void Save()
        {
            ctx.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            ctx.Entry(category).State = EntityState.Modified;
        }
    }
}
