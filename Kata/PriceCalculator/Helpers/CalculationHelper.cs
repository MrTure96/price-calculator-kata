using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.Helpers
{
    public static class CalculationHelper
    {
        public static decimal CalculateDiscountAmount(decimal price, decimal discountRate)
        {
            return RoundPrice(price / 100 * discountRate);
        }

        public static decimal CalculateTaxAmount(decimal price, decimal taxRate)
        {
            return RoundPrice(price / 100 * taxRate);
        }

        private static decimal RoundPrice(decimal price)
        {
            return Math.Round(price, 2);
        }
    }
}
