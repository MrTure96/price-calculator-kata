using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.Models
{
    public class Receipt
    {
        public Product Product { get; }
        public decimal TaxAmount { get; } = 0;
        public decimal DiscountAmount { get; } = 0;

        public Receipt(Product product, decimal taxAmount, decimal discountAmount)
        {
            Product = product;
            TaxAmount = taxAmount;
            DiscountAmount = discountAmount;
        }
    }
}
