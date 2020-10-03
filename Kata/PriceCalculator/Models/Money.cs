using System;

namespace PriceCalculator.Models
{
    public class Money
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Money(decimal amount, string currency = "$")
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money operator +(Money a, Money b)
            => new Money(a.Amount + b.Amount);

        public static Money operator -(Money a, Money b)
            => new Money(a.Amount - b.Amount);

        public static Money operator *(Money a, Money b)
            => new Money(a.Amount * b.Amount);

        public static Money operator /(Money a, Money b)
        {
            if (b.Amount == 0)
            {
                throw new DivideByZeroException();
            }
            return new Money(a.Amount / b.Amount);
        }
    }
}
