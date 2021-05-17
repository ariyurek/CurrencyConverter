using MediatR;
using System;
using System.Collections.Generic;

namespace CurrencyConverter.Application.Features.Queries
{
    public class GetCoinPriceListQuery : IRequest<List<CurrencyPrice>>
    {
        public string CoinCode { get; set; }

        public GetCoinPriceListQuery(string coinCode)
        {
            CoinCode = coinCode ?? throw new ArgumentNullException(nameof(coinCode));
        }
    }
}
