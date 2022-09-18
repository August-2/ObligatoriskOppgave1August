using Microsoft.EntityFrameworkCore;
using ObligatoriskOppgave1August.Data;
using ObligatoriskOppgave1August.Models.Entities;
using ObligatoriskOppgave1August.Models.ViewModels;
using System.Linq.Expressions;

namespace ObligatoriskOppgave1August.Models
{
    public class ProductRepository : IProductRepository
    {

        private ApplicationDbContext db;


        public ProductRepository(ApplicationDbContext db)
        {
            this.db = db;


        }

        public IEnumerable<Product> GetAll()
        {
            var products = db.Product
                .Include(cat => cat.Category)
                .Include(man => man.Manufacturer)
                .ToList();
            return products;
        }

        public IEnumerable<Product> GetProductById(int? id)
        {
            var product = db.Product.FirstOrDefault(u => u.ProductId == id);
                yield return product;
        }


        public void Save(Product product)
        {
            db.Add(product);
            db.SaveChanges();
        }

        public void Update(Product product)
        {
            db.Update(product);
            db.SaveChanges();
        }

        public void Remove(Product product)
        {
            db.Remove(product);
            db.SaveChanges();
        }

        public ProductEditViewModel GetProductEditViewModel()
        {
            var p = (from o in db.Product.Include("Category").Include("Manufacturer")
                select new ProductEditViewModel()).FirstOrDefault();
            p.Categories = db.Category.ToList();
            p.Manufacturers = db.Manufacturer.ToList();
            return p;
        }
    }
}
