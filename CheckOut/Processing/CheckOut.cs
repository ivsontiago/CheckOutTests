using CheckOut.Extensions;
using Newtonsoft.Json.Linq;

namespace CheckOut.Processing
{
    public class CheckOutCart
    {
        public static Price ProcessCart(JObject cart)
        {
            return Cart.CreateNewCart(cart).CalculatePrice();
        }
    }
}
