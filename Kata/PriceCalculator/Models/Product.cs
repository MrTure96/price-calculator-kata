namespace PriceCalculator.Models
{
    public class Product
    {
        public string Name { get; }
        public int UPC { get; }
        public decimal Price { get; }

        public Product(string name, int upc, decimal price)
        {
            Name = name;
            UPC = upc;
            Price = price;
        }
    }
}
