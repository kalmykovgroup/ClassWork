using ClassWork.Interfaces.Repositories;
using ClassWork.Models.Product;
using ClassWork.Models.Product.Drinks.Heirs;

namespace ClassWork.Repositories
{
    public class ProductRepository : IProductRepository
    {
        // Статический список напитков для примера
        private static readonly List<Product> Products = new List<Product>
        {
            new Tea("Чай", 100, 1){ Id = 1 },
            new Coffee("Кофе", 150, 1){ Id = 2},
            new Juice("Сок", 200, 2.3){ Id = 3},
        };

        public bool Delete(Product entity)
        {
            return Products.Remove(entity);
        }

        public Product? FindById(int id)
        {
            return Products.Where(p => p.Id == id).FirstOrDefault();
        }

        public Product? FindByName(string name)
        {
            return Products.Where(p => p.Name == name).FirstOrDefault();
        }

        public List<Product> GetAll()
        {
            return Products;
        }

        public bool Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
