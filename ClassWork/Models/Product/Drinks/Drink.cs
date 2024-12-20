using ClassWork.Intafraces.Product;

namespace ClassWork.Models.Product.Drinks
{
    public abstract class Drink : Product, IDrink
    {
        public abstract double Volume { get; set; } // Объём в мл

        protected Drink(string name, double price) : base(name, price){}

    }
}
