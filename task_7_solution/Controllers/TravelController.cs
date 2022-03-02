using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using task_7_solution.Services;
using System;
using task_7_solution.Models;
using task_7_solution.Models.DTOs.Requests;


namespace task_7_solution.Controllers
{
    [Route("api/trips")]
    [ApiController]

    public class TravelController : ControllerBase
    {
        private readonly IDatabaseService _service;
        public TravelController(IDatabaseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrips() 
        {
            var result = await _service.GetTrips();
            return Ok(result);
        }

        [HttpPost("{idTrip}/clients")]
        public async Task<IActionResult> CreateClientTrip(ClientTripDTO clientTripDTO) 
        {
            ClientTrip result = null;
            try {
                result = await _service.AssignClientToTrip(clientTripDTO);
                if(result == null)
                {
                    return NotFound();
                }
            } catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
            return CreatedAtAction(nameof(CreateClientTrip), new { id = result.IdClient }, result);
        }
    }
}