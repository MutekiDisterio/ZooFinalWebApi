using Microsoft.AspNetCore.Mvc;
using Zoo.BLL.DTOs.Animals;
using Zoo.BLL.Services.Interfaces;
using Zoo.DAL.Entity.HelpModels;
using Zoo.BLL.DTOs;
using System.Threading;

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
        public async Task<ActionResult<PagedResult<AnimalReadDto>>> GetAll([FromQuery] AnimalQueryParameters queryParameters, CancellationToken ct)
        {
            var result = await _animalService.GetPagedAsync(queryParameters, ct);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AnimalReadDto>> GetById(int id, CancellationToken ct)
        {
            var dto = await _animalService.GetByIdAsync(id, ct);
            return dto == null ? NotFound() : Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<AnimalReadDto>> Create([FromBody] AnimalCreateDto dto, CancellationToken ct)
        {
            var created = await _animalService.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<AnimalReadDto>> Update(int id, [FromBody] AnimalUpdateDto dto, CancellationToken ct)
        {
            if (id != dto.Id) return BadRequest("ID mismatch");
            var updated = await _animalService.UpdateAsync(id, dto, ct);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var deleted = await _animalService.DeleteAsync(id, ct);
            return deleted ? NoContent() : NotFound();
        }
    }
}