using AutoMapper; 
using CurrencyConverter.Application.Persistence;
using CurrencyConverter.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyConverter.Application.Features.Commands.AddCoinPrice
{
    public class AddCoinPriceCommandHandler : IRequestHandler<AddCoinPriceCommand, int>
    {
        private readonly IQuotesRepository _quotesRepository;
        private readonly IMapper _mapper; 
        private readonly ILogger<AddCoinPriceCommandHandler> _logger;
        public AddCoinPriceCommandHandler(IQuotesRepository quotesRepository, IMapper mapper, ILogger<AddCoinPriceCommandHandler> logger)
        {
            _quotesRepository = quotesRepository ?? throw new ArgumentNullException(nameof(_quotesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); 
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(AddCoinPriceCommand request, CancellationToken cancellationToken)
        {
            var quoteEntity = _mapper.Map<Quote>(request);
            var newQuote = await _quotesRepository.AddAsync(quoteEntity);

            _logger.LogInformation($"NewQuote {newQuote.Id} is successfully created."); 

            return newQuote.Id;
        }
    }
}
