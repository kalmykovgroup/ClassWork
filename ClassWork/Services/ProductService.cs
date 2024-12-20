using ClassWork.Interfaces.Repositories;
using ClassWork.Interfaces.Services;
using ClassWork.Models.Product;

namespace ClassWork.Services
{
    public class ProductService : Service<Product, IProductRepository>, IProductService
    {  

        public ProductService(IProductRepository productRepository) : base(productRepository){ }

        public Product? FindByName(string name)
        {
            return Repository.FindByName(name);
        }
    }
}
