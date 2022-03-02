using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using tutor_8_solution.Services;
using tutor_8_solution.Models;
using System.Net;

namespace tutor_8_solution.Controllers
{
    [Route("api/prescriptions")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IDatabaseService _service;
        public PrescriptionController(IDatabaseService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var result = await _service.GetPrescriptions();
            
            if (result == null)
            {
                return NotFound();
            }    

            return Ok(result);
        }

    }
}