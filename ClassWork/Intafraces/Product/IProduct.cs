using System.Text.Json;

namespace ClassWork.Intafraces.Product
{
    public interface IProduct
    {
        string Name { get; }
        double Price { get; }
        string GetJsonInfo(); // Метод для получения информации о продукте

    }
}
