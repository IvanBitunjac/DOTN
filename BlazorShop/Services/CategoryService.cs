using BlazorShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _db;
        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Category GetCategory(int categoryId)
        {
            return _db.Categories.FirstOrDefault(x => x.Id == categoryId);
        }

        public List<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }

        public bool CreateCategory(Category newCategory)
        {
            _db.Categories.Add(newCategory);
            //SaveChanges vraća broj zapisa koje je odradio, u ovom slučaju očekujemo da odradi 1
            return _db.SaveChanges() > 0;
        }

        public bool UpdateCategory(Category updateCategory)
        {
            Category existingCategory = _db.Categories.FirstOrDefault(x => x.Id == updateCategory.Id);
            //ako postoji ažuriraj
            if(existingCategory != null)
            {
                existingCategory.Name = updateCategory.Name;
                return _db.SaveChanges() > 0;
            }
            return false;         
        }

        public bool DeleteCategory(Category deleteCategory)
        {
            Category existingCategory = _db.Categories.FirstOrDefault(x => x.Id == deleteCategory.Id);
            //ako postoji obriši
            if (existingCategory != null)
            {
                _db.Categories.Remove(existingCategory);
                return _db.SaveChanges() > 0;

            }
            return false;
        }
    }
}
