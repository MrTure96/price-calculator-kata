using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.Models
{
    public class Receipt
    {
        public Product Product { get; }
        public Money TaxAmount { get; }
        public Money DiscountAmount { get; }

        public Receipt(Product product, Money taxAmount, Money discountAmount)
        {
            Product = product;
            TaxAmount = taxAmount;
            DiscountAmount = discountAmount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Price: {Product.Price.Currency}{Product.Price.Amount}");

            sb.AppendLine($"Tax amount: {TaxAmount.Currency}{TaxAmount.Amount}");

            if (DiscountAmount.Amount > 0)
                sb.AppendLine($"Discount amount: {TaxAmount.Currency}{DiscountAmount.Amount}");

            return sb.ToString();
        }
    }
}
