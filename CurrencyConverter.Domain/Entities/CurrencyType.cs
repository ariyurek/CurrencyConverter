using CurrencyConverter.Domain.Common;

namespace CurrencyConverter.Domain.Entities
{
    public class CurrencyType : Enumeration
    {
        public static CurrencyType USD = new CurrencyType(1, "USD");
        public static CurrencyType EUR = new CurrencyType(2, "EUR");
        public static CurrencyType BRL = new CurrencyType(3, "BRL");
        public static CurrencyType GBP = new CurrencyType(4, "GBP");
        public static CurrencyType AUD = new CurrencyType(5, "AUD");

        public CurrencyType(int id, string name) : base(id, name)
        {
        }
    }
}
