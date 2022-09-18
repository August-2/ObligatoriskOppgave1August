using ObligatoriskOppgave1August.Models.Entities;
using ObligatoriskOppgave1August.Models.ViewModels;
using System.Linq.Expressions;

namespace ObligatoriskOppgave1August.Models
{
    public interface IProductRepository{
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetProductById(int? id);
        void Save(Product product);
        void Update(Product product);
        void Remove(Product product);
        ProductEditViewModel GetProductEditViewModel();
    }
}
