using AutoMapper;
using CurrencyConverter.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyConverter.Application.Features.Queries
{
    public class GetCoinPriceListQueryHandler : IRequestHandler<GetCoinPriceListQuery, List<CurrencyPrice>>
    {
        private readonly IQuotesRepository _quotesRepository;
        private readonly IMapper _mapper;

        public GetCoinPriceListQueryHandler(IQuotesRepository quotesRepository, IMapper mapper)
        {
            _quotesRepository = quotesRepository ?? throw new ArgumentNullException(nameof(quotesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CurrencyPrice>> Handle(GetCoinPriceListQuery request, CancellationToken cancellationToken)
        {
            var currencyList = await _quotesRepository.GetCoinPriceByCoinCode(request.CoinCode);
            return _mapper.Map<List<CurrencyPrice>>(currencyList);
        }
    }
}
