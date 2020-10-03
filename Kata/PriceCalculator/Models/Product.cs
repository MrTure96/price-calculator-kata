namespace PriceCalculator.Models
{
    public class Product
    {
        public string Name { get; }
        public int UPC { get; }
        public Money Price { get; }

        public Product(string name, int upc, Money price)
        {
            Name = name;
            UPC = upc;
            Price = price;
        }
    }
}
