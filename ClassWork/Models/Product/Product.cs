using ClassWork.Extensions;
using ClassWork.Intafraces.Product;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassWork.Models.Product
{
    [JsonConverter(typeof(ProductJsonConverter))]
    public abstract class Product : BaseEntity, IProduct
    { 
        public string Name { get; } = string.Empty;
        public double Price { get; } 
 
        protected Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        [JsonIgnore]
        public JsonSerializerOptions JsonSerializerOptions { get; } = new JsonSerializerOptions
        {
            WriteIndented = true, // Форматированный вывод
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping // Поддержка русских букв без экранирования
        };

        public abstract string GetJsonInfo();
    }
}
