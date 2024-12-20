using ClassWork.Models.Product;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassWork.Extensions
{
    public class ProductJsonConverter : JsonConverter<Product>
    {
        public override Product Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException("Deserialization is not supported.");
        }

        public override void Write(Utf8JsonWriter writer, Product value, JsonSerializerOptions options)
        {
            // Вызываем GetJsonInfo для получения готового JSON
            string json = value.GetJsonInfo();

            // Парсим строку JSON и записываем её в текущий JSON
            using var jsonDoc = JsonDocument.Parse(json);
            jsonDoc.RootElement.WriteTo(writer);
        }
    }
}
