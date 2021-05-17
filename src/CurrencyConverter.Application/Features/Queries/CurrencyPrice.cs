using CurrencyConverter.Domain.Entities;

namespace CurrencyConverter.Application.Features.Queries
{
    public class CurrencyPrice
    { 
        public string CoinCode { get; set; }
        public CurrencyType Currency { get; set; }
        public double Price { get; set; }
    }
}
