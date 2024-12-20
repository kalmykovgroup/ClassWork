using ClassWork.Models.Product;

namespace ClassWork.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        public Product? FindByName(string name);
    }
}
