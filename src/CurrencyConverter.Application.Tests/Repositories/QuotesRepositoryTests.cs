using CurrencyConverter.Application.Persistence;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CurrencyConverter.Application.Tests.Repositories;
using System;

namespace CurrencyConverter.Application.Repositories.Tests
{
    [TestClass()]
    public class QuotesRepositoryTests
    {
        [TestMethod()]
        public void GetCoinPriceByCoinCodeTest()
        {
            //Setup 
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(ApiData.Payload),
            };
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);
            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri(Constants.ApiUrl),
            };
            var loggerMock = new Mock<ILogger<IQuotesRepository>>();
         
            var repo = new QuotesRepository(loggerMock.Object, httpClient);

            //Act
            var result = repo.GetCoinPriceByCoinCode("BTC");

            //Assert
            Assert.AreEqual(result.IsCompletedSuccessfully,true );
     
        }
    }
}