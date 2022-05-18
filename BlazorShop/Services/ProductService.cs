using BlazorShop.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlazorShop.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _db;
        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Product GetProduct(int productId)
        {
            return _db.Products.Include(x=>x.Category).FirstOrDefault(x => x.Id == productId);
        }

        public List<Product> GetProducts()
        {
            return _db.Products.Include(x=> x.Category).ToList();
        }

        public List<Category> GetCategoryList()
        {
            return _db.Categories.ToList();
        }

        public bool CreateProduct(Product newProduct)
        {
            _db.Products.Add(newProduct);
            //SaveChanges vraća broj zapisa koje je odradio, u ovom slučaju očekujemo da odradi 1
            return _db.SaveChanges() > 0;
        }

        public bool UpdateProduct(Product updateProduct)
        {
            Product existingProduct = _db.Products.FirstOrDefault(x => x.Id == updateProduct.Id);
            //ako postoji ažuriraj
            if (existingProduct != null)
            {             
                _db.Products.Update(updateProduct);
                return _db.SaveChanges() > 0;
            }
            return false;
        }

        public bool DeleteProduct(Product deleteProduct)
        {
            Product existingProduct = _db.Products.FirstOrDefault(x => x.Id == deleteProduct.Id);
            //ako postoji obriši
            if (existingProduct != null)
            {
                _db.Products.Remove(existingProduct);
                return _db.SaveChanges() > 0;

            }
            return false;
        }
    }
}
