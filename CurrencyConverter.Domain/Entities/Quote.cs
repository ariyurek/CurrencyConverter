using CurrencyConverter.Domain.Common;

namespace CurrencyConverter.Domain.Entities
{
    public class Quote : EntityBase
    {
        public string CoinCode { get; set; }
        public CurrencyType Currency { get; set; }
        public double Price { get; set; }
    }
}
