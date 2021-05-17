using CurrencyConverter.Application.Persistence;
using CurrencyConverter.Domain.Common;
using CurrencyConverter.Domain.Entities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CurrencyConverter.Application.Repositories
{
    public class QuotesRepository : IQuotesRepository
    {
        private readonly ILogger<IQuotesRepository> _logger;
        private readonly HttpClient _httpClient;
        public QuotesRepository(ILogger<IQuotesRepository> logger, HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            //TODO: Move to extension class
            _httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", Constants.ApiKey);
            _httpClient.DefaultRequestHeaders.Add("Accepts", "application/json");
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        } 

        private async Task<string> GetPriceFromCoinMarket(string coinCode, CurrencyType currencyType)
        {
            try
            {
                var URL = new UriBuilder(Constants.ApiUrl);

                var queryString = HttpUtility.ParseQueryString(string.Empty);
                queryString["symbol"] = coinCode;
                queryString["convert"] = currencyType.Name;

                URL.Query = queryString.ToString(); 
                return await _httpClient.GetAsync(URL.Uri).Result.Content.ReadAsStringAsync();
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetPriceFromCoinMarket method is failed.{ex.Message}");
                throw;
            }

        }

        public async Task<IEnumerable<Quote>> GetCoinPriceByCoinCode(string coinCode)
        {
            _logger.LogInformation($"GetCoinPriceByCoinCode is successfully called for {coinCode}.");
            var quoteList = new List<Quote>();
            foreach (var item in Enumeration.GetAll<CurrencyType>())
            { 
                var apiResult = await GetPriceFromCoinMarket(coinCode, item);
                var deserializedResult = JsonConvert.DeserializeObject<JObject>(apiResult);
                foreach (JProperty property in deserializedResult.Properties()) {                    
                    if (property.Name == "data") {
                        var currencyObject = property.Value.First.First.SelectToken("quote").SelectToken(item.Name);
                        if (currencyObject is not null)
                            quoteList.Add(new Quote()
                            {
                                CreatedBy = nameof(GetCoinPriceByCoinCode),
                                CreatedDate = DateTime.Now,
                                LastModifiedBy = nameof(GetCoinPriceByCoinCode),
                                LastModifiedDate = DateTime.Now,
                                Currency = item,
                                CoinCode = coinCode,
                                Price = (double)currencyObject.SelectToken("price")
                            });
                    }
                }
            }
            return quoteList; 
        }

        public Task<Quote> AddAsync(Quote entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Quote entity)
        {
            throw new NotImplementedException();
        }

        public Task<Quote> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Quote entity)
        {
            throw new NotImplementedException();
        }
    }
}
