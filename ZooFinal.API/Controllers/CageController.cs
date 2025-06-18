using Microsoft.AspNetCore.Mvc;
using Zoo.BLL.DTOs.Cages;
using Zoo.BLL.Services.Interfaces;

namespace Zoo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CageController : ControllerBase
    {
        private readonly ICageService _cageService;

        public CageController(ICageService cageService)
        {
            _cageService = cageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CageReadDto>>> GetAll(CancellationToken ct)
        {
            var cages = await _cageService.GetAllAsync(ct);
            return Ok(cages);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CageReadDto>> GetById(int id, CancellationToken ct)
        {
            var cage = await _cageService.GetByIdAsync(id, ct);
            if (cage == null)
                return NotFound();
            return Ok(cage);
        }

        [HttpPost]
        public async Task<ActionResult<CageReadDto>> Create([FromBody] CageCreateDto dto, CancellationToken ct)
        {
            var created = await _cageService.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<CageReadDto>> Update(int id, [FromBody] CageUpdateDto dto, CancellationToken ct)
        {
            if (id != dto.Id)
                return BadRequest("Id in URL and DTO must match.");

            var updated = await _cageService.UpdateAsync(id, dto, ct);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var deleted = await _cageService.DeleteAsync(id, ct);
            return deleted ? NoContent() : NotFound();
        }
    }
}
