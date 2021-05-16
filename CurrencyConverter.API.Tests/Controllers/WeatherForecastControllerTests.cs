using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyConverter.API.Controllers; 
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;


namespace CurrencyConverter.API.Controllers.Tests
{
    [TestClass()]
    public class WeatherForecastControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            //Setup
            var loggerMock = new Mock<ILogger<WeatherForecastController>>(); 
            var api = new WeatherForecastController(loggerMock.Object);
            //Act
            var response = api.Response;
        }
    }
}