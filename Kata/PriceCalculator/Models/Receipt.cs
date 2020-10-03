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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Price: " + Product.Price.ToString());

            sb.AppendLine("Tax amount: " + TaxAmount.ToString());

            if (DiscountAmount > 0)
                sb.AppendLine("Discount amount: " + DiscountAmount.ToString());

            return sb.ToString();
        }
    }
}
