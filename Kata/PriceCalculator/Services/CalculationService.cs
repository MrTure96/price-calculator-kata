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
            decimal taxAmount = CalculationHelper.CalculateTaxAmount(product.Price.Amount, TaxRate);
            decimal discountAmount = CalculationHelper.CalculateDiscountAmount(product.Price.Amount, DiscountRate);

            Product finalProduct = new Product(product.Name, product.UPC, CalculatePrice(product.Price.Amount, taxAmount, discountAmount));

            return new Receipt
            (
                finalProduct,
                taxAmount,
                discountAmount
            );
        }

        private Money CalculatePrice(decimal productPrice, decimal taxAmount, decimal discountAmount)
        {
            return new Money(productPrice + taxAmount - discountAmount);
        }
    }
}
