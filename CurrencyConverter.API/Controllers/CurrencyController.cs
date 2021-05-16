using CurrencyConverter.Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CurrencyController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        } 

        [HttpGet("{coinCode}", Name = "GetOrder")]
        [ProducesResponseType(typeof(IEnumerable<CurrencyPrice>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CurrencyPrice>>> GetCoinPriceByCoinCode(string coinCode)
        {
            var query = new GetCoinPriceListQuery(coinCode);
            var currencyPrice = await _mediator.Send(query);
            return Ok(currencyPrice);
        }
    }
}
