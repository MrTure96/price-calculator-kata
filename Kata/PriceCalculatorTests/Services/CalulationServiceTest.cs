using PriceCalculator.Models;
using PriceCalculator.Services;
using Xunit;

namespace PriceCalculatorTests.Services
{
    public class CalulationServiceTest
    {
        private const string PRODUCT_NAME = "The Little Prince";
        private const int UPC = 12345;
        private const decimal PRICE = 20.25m;

        [Theory]
        [InlineData(21, 24.50)]
        [InlineData(20, 24.30)]
        public void Caclulate_TaxRatePassed_ProductWithAppliedTax(decimal taxRate, float expectedPriceInt)
        {
            // Arrange
            CalculationService calculationService = new CalculationService(taxRate);

            decimal expectedPrice = (decimal)expectedPriceInt;
            Product testProduct = new Product
            (
                PRODUCT_NAME,
                UPC,
                new Money(PRICE)
            );

            // Act
            Receipt result = calculationService.Calculate(testProduct);

            // Assert
            Assert.Equal(PRODUCT_NAME, result.Product.Name);
            Assert.Equal(UPC, result.Product.UPC);
            Assert.Equal(expectedPrice, result.Product.Price.Amount);
        }

        [Theory]
        [InlineData(20, 15, 21.26)]
        public void Caclulate_DiscountRateAndTaxRate_ProductWithAppliedTax(decimal taxRate, decimal discountRate, float expectedPriceInt)
        {
            // Arrange
            CalculationService calculationService = new CalculationService(taxRate, discountRate);

            decimal expectedPrice = (decimal)expectedPriceInt;
            Product testProduct = new Product
            (
                PRODUCT_NAME,
                UPC,
                new Money(PRICE)
            );

            // Act
            Receipt result = calculationService.Calculate(testProduct);

            // Assert
            Assert.Equal(PRODUCT_NAME, result.Product.Name);
            Assert.Equal(UPC, result.Product.UPC);
            Assert.Equal(expectedPrice, result.Product.Price.Amount);
            Assert.Equal(3.04m, result.DiscountAmount);
            Assert.Equal(4.05m, result.TaxAmount);
        }
    }
}
