using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Application.Commands;
using Service.Application.Queries;
using Service.Application.ReturnModels;

namespace Service.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IMediator _mediator;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IMediator mediator,ILogger<WeatherForecastController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Example API method for data retrieval
        /// </summary>
        /// <returns>An array of sample objects</returns>
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<WeatherForecastView>>> GetAsync()
        {
            var result = await _mediator.Send(new GetForecasts());
            return Ok(result);
        }

        /// <summary>
        /// Example API method for data retrieval
        /// </summary>
        /// <returns>An array of sample objects</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<WeatherForecastView>> GetByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new GetForecastById(id));
            return Ok(result);
        }

        /// <summary>
        /// Example API method for data retrieval
        /// </summary>
        /// <returns>An array of sample objects</returns>
        [HttpGet("latest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<WeatherForecastView>> GetLatestAsync()
        {
            var result = await _mediator.Send(new GetLatestForecast());
            return Ok(result);
        }

        /// <summary>
        /// Example API method for creating a resource
        /// </summary>
        /// <returns>The created resource</returns>
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<WeatherForecastView>> CreateAsync()
        {
            var result = await _mediator.Send(new CreateNewForecast());
            return CreatedAtRoute(new {  }, result);
        }

        /// <summary>
        /// Example API method for updating a resource
        /// </summary>
        /// <returns>The created resource</returns>
        [HttpPut("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<WeatherForecastView>> UpdateAsync(UpdateForecast forecast)
        {
            var result = await _mediator.Send(forecast);
            return Ok(result);
        }
    }
}
