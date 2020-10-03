using PriceCalculator.Helpers;
using PriceCalculator.Models;

namespace PriceCalculator.Services
{
    public class CalculationService
    {
        private readonly decimal TaxRate;
        private readonly decimal DiscountRate;

        public CalculationService(decimal taxRate = 0, decimal discountRate = 0)
        {
            TaxRate = taxRate;
            DiscountRate = discountRate;
        }

        public Receipt Calculate(Product product)
        {
            decimal taxAmount = CalculationHelper.CalculateTaxAmount(product.Price, TaxRate);
            decimal discountAmount = CalculationHelper.CalculateDiscountAmount(product.Price, DiscountRate);

            Product finalProduct = new Product(product.Name, product.UPC, CalculatePrice(product.Price, taxAmount, discountAmount));

            return new Receipt
            (
                finalProduct,
                taxAmount,
                discountAmount
            );
        }

        private decimal CalculatePrice(decimal productPrice, decimal taxAmount, decimal discountAmount)
        {
            return productPrice + taxAmount - discountAmount;
        }
    }
}
