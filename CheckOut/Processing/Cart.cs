using System;
using System.Linq;
using CheckOut.Enums;
using CheckOut.Fruits;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CheckOut.Processing
{
    public class Cart
    {
        public Cart()
        {
            Apple = new Apple();
            Orange = new Orange();
        }

        public Apple Apple { get; set; }
        public Orange Orange { get; set; }

        public static Cart CreateNewCart(JObject cart)
        {
            return new Cart
            {
                Apple = new Apple
                {
                    Quantity = GetQuantity(cart, ProductTypes.Apple)
                },
                Orange = new Orange
                {
                    Quantity = GetQuantity(cart, ProductTypes.Orange)
                }
            };
        }

        private static int GetQuantity(JObject cart, ProductTypes product)
        {
            foreach (var item in cart)
            {
                if (!item.Key.Contains(product.ToString()) && !IsValidJson(item.Value.ToString())) continue;
                if (!IsValidJson(item.Value.ToString())) continue;
                foreach (var cartProduct in (JObject)item.Value)
                    if (IsValidJson(cartProduct.Value.ToString()))
                        foreach (var singleItem in cartProduct.Value.ToArray())
                            if (((JProperty)singleItem).Name.Contains(product.ToString()))
                                return int.Parse(singleItem.First.ToString());
            }
            return 0;
        }

        private static bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((!strInput.StartsWith("{") || !strInput.EndsWith("}")) &&
                (!strInput.StartsWith("[") || !strInput.EndsWith("]"))) return false;
            try
            {
                JToken.Parse(strInput);
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}