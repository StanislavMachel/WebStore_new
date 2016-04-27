using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Domain.Entities;

namespace WebStore.Domain.Abstract
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetGategories();
        Category GetCategoryById(int? id);
        ObservableCollection<Category> CategoriesInMemory();
        void AddNewCategory(Category category);
        void DeleteCategory(int id);
        void UpdateCategory(Category Category);
        void Dispose();
        void Save();
    }
}
