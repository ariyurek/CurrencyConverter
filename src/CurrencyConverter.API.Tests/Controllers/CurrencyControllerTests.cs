using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MediatR;

namespace CurrencyConverter.API.Controllers.Tests
{
    [TestClass()]
    public class CurrencyControllerTests
    {
        [TestMethod()]
        public void GetCoinPriceByCoinCodeTest()
        {
            //Setup 
            var mediator = new Mock<IMediator>();
            var api = new CurrencyController(mediator.Object);
            //Act
            var response = api.GetCoinPriceByCoinCode("BTC");
        }
    }
}