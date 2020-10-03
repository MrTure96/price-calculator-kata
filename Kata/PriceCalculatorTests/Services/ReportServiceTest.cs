using PriceCalculator.Models;
using PriceCalculator.Services;
using System;
using System.Text;
using Xunit;

namespace PriceCalculatorTests.Services
{
    public class ReportServiceTest
    {
        private const string PRODUCT_NAME = "The Little Prince";
        private const int UPC = 12345;
        private const decimal PRICE = 21.25m;
        private const decimal TAX_AMOUNT = 3.04m;
        private const decimal DISCOUNT_AMOUNT = 3.04m;

        public void GenerateReport_ReceiptWithDiscountAmountPassed_ProductWithAppliedTax()
        {
            // Arrange
            ReportService reportService = new ReportService();
            StringBuilder expectedResult = new StringBuilder();
            expectedResult.AppendLine($"Price: ${PRICE}");
            expectedResult.AppendLine($"Tax amount: ${TAX_AMOUNT}");
            expectedResult.AppendLine($"Discount amount: ${DISCOUNT_AMOUNT}");

            Product product = new Product(PRODUCT_NAME, UPC, new Money(PRICE));

            Receipt receipt = new Receipt(product, new Money(TAX_AMOUNT), new Money(DISCOUNT_AMOUNT));

            // Act
            String result = reportService.GenerateReport(receipt);

            // Assert
            Assert.Equal(expectedResult.ToString(), result);
        }
    }
}