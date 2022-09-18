using ObligatoriskOppgave1August.Data;
using ObligatoriskOppgave1August.Models.Entities;

namespace ObligatoriskOppgave1August.Models
{
    public class ProductRepository: IProductRepository
    {

        private ApplicationDbContext db;

        public ProductRepository(ApplicationDbContext db)
        {
            this.db = db;

        }
        public IEnumerable<Product> GetAll()
        {
            var products = db.Product;
            return products;
        }

        public void Save(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
