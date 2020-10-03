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
        public void CaclulateTax_CorrectArgumentPassed_ProductWithAppliedTax(decimal taxRate, float expectedPriceInt)
        {
            // Arrange
            CalculationService calculationService = new CalculationService();
            decimal expectedPrice = (decimal)expectedPriceInt;
            Product testProduct = new Product
            (
                PRODUCT_NAME,
                UPC,
                PRICE
            );

            // Act
            Product result = calculationService.ApplyTax(testProduct, taxRate);

            // Assert
            Assert.Equal(PRODUCT_NAME, result.Name);
            Assert.Equal(UPC, result.UPC);
            Assert.Equal(expectedPrice, result.Price);
        }
    }
}
