using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using tutor_8_solution.Services;
using tutor_8_solution.Models;
using System.Net;
using tutor_8_solution.Models.DTOs.Responses;

namespace tutor_8_solution.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDatabaseService _service;
        public DoctorController(IDatabaseService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var result = await _service.GetDoctors();
            
            if (result == null)
            {
                return NotFound();
            }    

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor(DoctorDTO doctor)
        {
            if(doctor == null)
            {
                return BadRequest();
            }

            var result = await _service.AddDoctor(doctor);
            
            if (result != null)
            {
                return StatusCode((int)HttpStatusCode.Created);
            }
            else 
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
        [HttpDelete("{idDoctor}")]
        public async Task<IActionResult> DeleteDoctor(int idDoctor)
        {
            if (await _service.IsExistingDoctor(idDoctor) == false)
            {
                return NotFound();
            }
            else if(await _service.IsExistingDoctor(idDoctor) == true)
            {
                await _service.DeleteDoctor(idDoctor);
                return NoContent();
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDoctor(Doctor doctor)
        {
            if(doctor == null)
            {
                return BadRequest();
            }

            if (await _service.IsExistingDoctor(doctor.IdDoctor) == false)
            {
                return NotFound();
            }
            else if(await _service.IsExistingDoctor(doctor.IdDoctor) == true)
            {
                await _service.UpdateDoctor(doctor);
                return Ok();
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}