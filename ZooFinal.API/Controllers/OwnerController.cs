using Microsoft.AspNetCore.Mvc;
using Zoo.BLL.DTOs.Owners;
using Zoo.BLL.Services;
using Zoo.BLL.Services.Interfaces;
using Zoo.DAL.Entity.HelpModels;
using Zoo.BLL.DTOs;
using System.Threading;
using OwnerQueryParameters = Zoo.BLL.Services.OwnerQueryParameters;


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
        public async Task<ActionResult<PagedResult<OwnerReadDto>>> GetAll([FromQuery] OwnerQueryParameters queryParameters, CancellationToken ct)
        {
            var result = await _ownerService.GetPagedAsync(queryParameters, ct);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<OwnerReadDto>> GetById(int id, CancellationToken ct)
        {
            var dto = await _ownerService.GetByIdAsync(id, ct);
            return dto == null ? NotFound() : Ok(dto);
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
            if (id != dto.Id) return BadRequest("ID mismatch");
            var updated = await _ownerService.UpdateAsync(id, dto, ct);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var deleted = await _ownerService.DeleteAsync(id, ct);
            return deleted ? NoContent() : NotFound();
        }
    }
}