using ClassWork.Intafraces.Product;
using System.Text.Json;

namespace ClassWork.Models.Product.Drinks.Heirs
{
    public class Juice : Drink
    {
        public override double Volume { get; set; }

        public Juice(string name, double price, double volume) : base(name, price)
        {
            Volume = volume;
        }
         public override string GetJsonInfo() => JsonSerializer.Serialize(this, JsonSerializerOptions);

    }
}
