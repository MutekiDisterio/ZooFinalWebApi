using Microsoft.AspNetCore.Mvc;
using Zoo.BLL.DTOs.AnimalTypes;
using Zoo.BLL.Services.Interfaces;

namespace Zoo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalTypeController : ControllerBase
    {
        private readonly IAnimalTypeService _animalTypeService;

        public AnimalTypeController(IAnimalTypeService animalTypeService)
        {
            _animalTypeService = animalTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalTypeReadDto>>> GetAll(CancellationToken ct)
        {
            var types = await _animalTypeService.GetAllAsync(ct);
            return Ok(types);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AnimalTypeReadDto>> GetById(int id, CancellationToken ct)
        {
            var type = await _animalTypeService.GetByIdAsync(id, ct);
            if (type == null)
                return NotFound();
            return Ok(type);
        }

        [HttpPost]
        public async Task<ActionResult<AnimalTypeReadDto>> Create([FromBody] AnimalTypeCreateDto dto, CancellationToken ct)
        {
            var created = await _animalTypeService.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<AnimalTypeReadDto>> Update(int id, [FromBody] AnimalTypeUpdateDto dto, CancellationToken ct)
        {
            if (id != dto.Id)
                return BadRequest("Id in URL and DTO must match.");

            var updated = await _animalTypeService.UpdateAsync(id, dto, ct);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var deleted = await _animalTypeService.DeleteAsync(id, ct);
            return deleted ? NoContent() : NotFound();
        }
    }
}
