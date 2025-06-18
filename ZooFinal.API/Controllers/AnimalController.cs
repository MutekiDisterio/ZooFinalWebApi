using Microsoft.AspNetCore.Mvc;
using Zoo.BLL.DTOs.Animals;
using Zoo.BLL.Services.Interfaces;

namespace Zoo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalReadDto>>> GetAll(CancellationToken ct)
        {
            var animals = await _animalService.GetAllAsync(ct);
            return Ok(animals);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AnimalReadDto>> GetById(int id, CancellationToken ct)
        {
            var animal = await _animalService.GetByIdAsync(id, ct);
            if (animal == null)
                return NotFound();
            return Ok(animal);
        }

        [HttpPost]
        public async Task<ActionResult<AnimalReadDto>> Create([FromBody] AnimalCreateDto dto, CancellationToken ct)
        {
            var createdAnimal = await _animalService.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetById), new { id = createdAnimal.Id }, createdAnimal);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<AnimalReadDto>> Update(int id, [FromBody] AnimalUpdateDto dto, CancellationToken ct)
        {
            if (id != dto.Id)
                return BadRequest("Id in URL and DTO must match.");

            var updatedAnimal = await _animalService.UpdateAsync(id, dto, ct);
            if (updatedAnimal == null)
                return NotFound();

            return Ok(updatedAnimal);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var deleted = await _animalService.DeleteAsync(id, ct);
            return deleted ? NoContent() : NotFound();
        }
    }
}
