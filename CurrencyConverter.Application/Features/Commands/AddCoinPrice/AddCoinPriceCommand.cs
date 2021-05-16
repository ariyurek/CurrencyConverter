using CurrencyConverter.Domain.Entities;
using MediatR;

namespace CurrencyConverter.Application.Features.Commands.AddCoinPrice
{
   public class AddCoinPriceCommand : IRequest<int>
    {
        public string CoinCode { get; set; }
        public CurrencyType Currency { get; set; }
        public double Price { get; set; }
    }
}
