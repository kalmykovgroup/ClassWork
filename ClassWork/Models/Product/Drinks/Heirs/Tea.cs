﻿using ClassWork.Intafraces;
using ClassWork.Intafraces.Product;
using System.Text.Json;

namespace ClassWork.Models.Product.Drinks.Heirs
{
    public class Tea : Drink
    {

        public override double Volume { get; set; }

        public Tea(string name, double price, double volume) : base(name, price)
        {
            Volume = volume;
        }

        public override string GetJsonInfo() => JsonSerializer.Serialize(this, JsonSerializerOptions);

        
    }
}
