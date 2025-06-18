using Microsoft.AspNetCore.Mvc;
using Zoo.BLL.DTOs.AnimalsCages;
using Zoo.BLL.Services.Interfaces;

namespace Zoo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalCageController : ControllerBase
    {
        private readonly IAnimalCageService _animalCageService;

        public AnimalCageController(IAnimalCageService animalCageService)
        {
            _animalCageService = animalCageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalCageDto>>> GetAll(CancellationToken ct)
        {
            var list = await _animalCageService.GetAllAsync(ct);
            return Ok(list);
        }

        [HttpGet("{animalId:int}/{cageId:int}")]
        public async Task<ActionResult<AnimalCageDto>> GetById(int animalId, int cageId, CancellationToken ct)
        {
            var dto = await _animalCageService.GetByIdAsync(animalId, cageId, ct);
            if (dto == null)
                return NotFound();
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<AnimalCageDto>> Create([FromBody] AnimalCageDto dto, CancellationToken ct)
        {
            var created = await _animalCageService.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetById), new { animalId = created.AnimalId, cageId = created.CageId }, created);
        }

        [HttpPut("{animalId:int}/{cageId:int}")]
        public async Task<ActionResult<AnimalCageDto>> Update(int animalId, int cageId, [FromBody] AnimalCageDto dto, CancellationToken ct)
        {
            if (animalId != dto.AnimalId || cageId != dto.CageId)
                return BadRequest("IDs in URL and DTO must match.");

            var updated = await _animalCageService.UpdateAsync(animalId, cageId, dto, ct);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{animalId:int}/{cageId:int}")]
        public async Task<IActionResult> Delete(int animalId, int cageId, CancellationToken ct)
        {
            var deleted = await _animalCageService.DeleteAsync(animalId, cageId, ct);
            return deleted ? NoContent() : NotFound();
        }
    }
}
