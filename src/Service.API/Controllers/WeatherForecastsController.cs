using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Application.Commands;
using Service.Application.DTOs;
using Service.Application.Queries;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Service.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherForecastsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Example API method for data retrieval
        /// </summary>
        /// <returns>An array of all objects</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<WeatherForecastDto>>> GetAllAsync(CancellationToken ct = default)
        {
            var result = await _mediator.Send(new GetAllWeatherForecasts(), ct);
            return Ok(result);
        }

        /// <summary>
        /// Example API method for data retrieval
        /// </summary>
        /// <returns>An objects</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<WeatherForecastDto>> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            var result = await _mediator.Send(new GetForecastById(id), ct);
            return Ok(result);
        }

        /// <summary>
        /// Example API method for data retrieval
        /// </summary>
        /// <returns>An objects</returns>
        [HttpGet("latest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<WeatherForecastDto>> GetLatestAsync(CancellationToken ct = default)
        {
            var result = await _mediator.Send(new GetLatestForecast(), ct);
            return Ok(result);
        }

        /// <summary>
        /// Example API method for creating a resource
        /// </summary>
        /// <returns>The created resource</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<WeatherForecastDto>> CreateAsync([FromBody]CreateWeatherForecastDto createWeatherForecastDto, CancellationToken ct = default)
        {
            var result = await _mediator.Send(new CreateNewWeatherForecast(createWeatherForecastDto), ct);
            return CreatedAtAction(nameof(GetByIdAsync), result);
        }

        /// <summary>
        /// Example API method for updating a resource
        /// </summary>
        /// <returns>The updated resource</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<WeatherForecastDto>> UpdateAsync([FromBody]UpdateWeatherForecastDto forecast, Guid id, CancellationToken ct = default)
        {
            var result = await _mediator.Send(new UpdateForecast(id, forecast), ct);
            return Ok(result);
        }
    }
}
