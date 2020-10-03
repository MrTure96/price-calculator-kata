using PriceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.Helpers
{
    public static class CalculationHelper
    {
        public static Money CalculateDiscountAmount(decimal price, decimal discountRate)
        {
            return new Money(RoundPrice(price / 100 * discountRate));
        }

        public static Money CalculateTaxAmount(decimal price, decimal taxRate)
        {
            return new Money(RoundPrice(price / 100 * taxRate));
        }

        private static decimal RoundPrice(decimal price)
        {
            return Math.Round(price, 2);
        }
    }
}
