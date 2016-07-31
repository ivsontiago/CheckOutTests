using CheckOut.Processing;

namespace CheckOut.Extensions
{
    public static class ExtensionMethods
    {
        public static Price CalculatePrice(this Cart cart)
        {
            return new Price()
            {
                Currency = "£",
                Value = Price.CalculateTotalPrice(cart)
            };
        }
    }
}
