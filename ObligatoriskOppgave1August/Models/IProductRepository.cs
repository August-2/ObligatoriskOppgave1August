using ObligatoriskOppgave1August.Models.Entities;

namespace ObligatoriskOppgave1August.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        void Save(Product product);
    }
}
