using PriceCalculator.Models;
using System;

namespace PriceCalculator.Services
{
    public class CalculationService
    {
        public Product ApplyTax(Product product, decimal taxRate)
        {
            return new Product
            (
                product.Name,
                product.UPC,
                product.Price + Math.Round(product.Price / 100 * taxRate, 2)
            );
        }
    }
}
