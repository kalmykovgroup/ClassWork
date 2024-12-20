using ClassWork.Interfaces.Repositories;
using ClassWork.Models.Product;
using ClassWork.Models.Product.Drinks.Heirs;

namespace ClassWork.Interfaces.Services
{
    public interface IProductService : IService<Product, IProductRepository>
    {
        public Product? FindByName(string name);
    }
}
