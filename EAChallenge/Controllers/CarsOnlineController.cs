using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EAChallenge.Domain.DTO;
using EAChallenge.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EAChallenge.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CarsOnlineController : ControllerBase
    {
        private readonly ICarDetailsService _carDetailsService;
        public CarsOnlineController(ICarDetailsService carDetailsService)
        {
            _carDetailsService = carDetailsService;
        }

        // GET: api/<CarsOnlineController>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(CarDetailsDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCars([FromQuery]string culture, int pageNumber, int pageSize)
        {
            try
            {
                SearchParameters request = new SearchParameters { Culture = culture, PageNumber = pageNumber, PageSize = pageSize };
                var result = await _carDetailsService.GetCarDetails(request);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
