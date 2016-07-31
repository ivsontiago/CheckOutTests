namespace CheckOut.Fruits
{
    internal interface IFruit
    {
        double ProductPrice { get; }
        int Quantity { get; set; }
    }
}