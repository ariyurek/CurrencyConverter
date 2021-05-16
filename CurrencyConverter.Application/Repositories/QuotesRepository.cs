using CurrencyConverter.Application.Persistence;
using CurrencyConverter.Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace CurrencyConverter.Application.Repositories
{
    public class QuotesRepository : IQuotesRepository
    {
        private static string API_KEY = "eb7c6935-5199-4488-86aa-53cd442ec3cc";

        static string makeAPICall()
        {  
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/quotes/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["symbol"] = "BTC";
            queryString["convert"] = "USD";

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");
            return client.DownloadString(URL.ToString());

        }

        public Task<IEnumerable<Quote>> GetCoinPriceByCoinCode(string coinCode)
        {
            var item = new Quote();
            var result = makeAPICall();
            var res = JsonConvert.DeserializeObject<JObject>(result);
            double price = 0;
            foreach (JProperty property in res.Properties())
            {
                //Console.WriteLine(property.Name + " - " + property.Value);
                if (property.Name == "data")
                {
                    item.Price = (double)property.Value.First.First.SelectToken("quote").SelectToken("USD").SelectToken("price");

                }
            }
            throw new NotImplementedException();
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
