using Microsoft.AspNetCore.Mvc;
using task_4_Solution.Services;
using task_4_Solution.Models;

namespace task_4_solution.Controller
{
    [Route("api/animals")]
    [ApiController]

    public class AnimalController : ControllerBase
    {

        public AnimalController(IDatabaseService dbService)
        {
            _dbService = dbService;
        }

        private IDatabaseService _dbService;


        [HttpGet]
        public IActionResult GetAnimals(string orderBy)
        {
            return Ok(_dbService.GetAnimals(orderBy));
        }
        [HttpDelete("{idAnimal}")]
        public IActionResult DeleteAnimals(int idAnimal)
        {
            if (_dbService.DeleteAnimals(idAnimal) == 0)
            {
                // $"Object with id {idAnimal} does not exist.";
                return NotFound($"Object with id {idAnimal} does not exist.");
            }
                    else
            {
                // $"Object with id {idAnimal} was deleted";
                return Ok($"Object with id {idAnimal} was deleted");
            }

            // return Ok(_dbService.DeleteAnimals(idAnimal));
        }

        [HttpPost]
        public IActionResult AddAnimals(Animal animal)
        {
            return Ok(_dbService.AddAnimals(animal));
        }

        [HttpPut("{idAnimal}")]
        public IActionResult UpdateAnimals(int idAnimal, Animal newAnimal)
        {
            return Ok(_dbService.UpdateAnimals(idAnimal, newAnimal));
        }

    }
}