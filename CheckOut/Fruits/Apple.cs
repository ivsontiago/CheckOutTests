using CheckOut.Enums;
using CheckOut.Processing;

namespace CheckOut.Fruits
{
    public class Apple : IFruit
    {
        public int Quantity { get; set; }
        public double ProductPrice => Price.GetProductPrice(ProductTypes.Apple);
    }
}