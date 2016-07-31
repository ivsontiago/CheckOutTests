using CheckOut.Enums;
using CheckOut.Processing;

namespace CheckOut.Fruits
{
    public class Orange : IFruit
    {
        public int Quantity { get; set; }
        public double ProductPrice => Price.GetProductPrice(ProductTypes.Orange);
    }
}