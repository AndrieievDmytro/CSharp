using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using task_7_solution.Services;
// using task_4_Solution.Models;

namespace task_7_solution.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
         private readonly IDatabaseService _service;
        public ClientController(IDatabaseService service)
        {
            _service = service;
        }

        [HttpDelete("{idClient}")]
        public async Task<IActionResult> DeleteClient(int idClient)
        {
            try {
                await _service.DeleteClient(idClient);
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
            return NoContent();
        } 
    }
}