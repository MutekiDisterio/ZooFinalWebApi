using Microsoft.AspNetCore.Mvc;
using Zoo.BLL.DTOs.Owners;
using Zoo.BLL.Services.Interfaces;

namespace Zoo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnerReadDto>>> GetAll(CancellationToken ct)
        {
            var list = await _ownerService.GetAllAsync(ct);
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<OwnerReadDto>> GetById(int id, CancellationToken ct)
        {
            var dto = await _ownerService.GetByIdAsync(id, ct);
            return dto is null ? NotFound() : Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<OwnerReadDto>> Create([FromBody] OwnerCreateDto dto, CancellationToken ct)
        {
            var created = await _ownerService.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<OwnerReadDto>> Update(int id, [FromBody] OwnerUpdateDto dto, CancellationToken ct)
        {
            if (id != dto.Id) return BadRequest("ID in URL and payload must match.");

            var updated = await _ownerService.UpdateAsync(id, dto, ct);
            return updated is null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            return await _ownerService.DeleteAsync(id, ct) ? NoContent() : NotFound();
        }
    }
}
