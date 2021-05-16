using CurrencyConverter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Application.Persistence
{
    public interface IQuotesRepository : IAsyncRepository<Quote>
    {
        Task<IEnumerable<Quote>> GetCoinPriceByCoinCode(string coinCode); 
    }
}
