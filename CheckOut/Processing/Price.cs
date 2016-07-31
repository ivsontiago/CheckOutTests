using System.IO;
using System.Linq;
using System.Reflection;
using CheckOut.Enums;
using CheckOut.Fruits;
using Newtonsoft.Json.Linq;

namespace CheckOut.Processing
{
    public class Price
    {
        public string Currency { get; set; }
        public double Value { get; set; }

        public static double GetPrice<T>(T fruitPrice)
        {
            switch (fruitPrice.GetType().Name)
            {
                case nameof(Apple):
                    return 0;
                case nameof(Orange):
                    return 0;
            }
            return 0;
        }

        public static double GetProductPrice(ProductTypes product)
        {
            var prices = ReadPricesFromJson();

            var fruits = (JArray)JObject.Parse(prices["items"].ToString())["fruits"];
            var productPrices = fruits.ToArray();
            foreach (var productPrice in productPrices)
            {
                if (!productPrice.ToArray().Any(details => details.ToArray().Contains(product.ToString())))
                    continue;

                foreach (var prop in productPrice)
                {
                    if (prop.ToString().Contains("price"))
                    {
                        return double.Parse(prop.First.ToString());
                    }
                }
            }
            return 0;
        }

        private static JObject ReadPricesFromJson()
        {
            var assembly = Assembly.GetExecutingAssembly();
            const string resourceName = "CheckOut.Resources.Prices.Prices.json";
            var result = string.Empty;

            using (var stream = assembly.GetManifestResourceStream(resourceName))
                if (stream != null)
                    using (var reader = new StreamReader(stream))
                    {
                        result = reader.ReadToEnd();
                    }
            return JObject.Parse(result);
        }

        public static double CalculateTotalPrice(Cart cart)
        {
            return cart.Apple.ProductPrice * cart.Apple.Quantity
                + cart.Orange.ProductPrice * cart.Orange.Quantity;
        }
    }
}