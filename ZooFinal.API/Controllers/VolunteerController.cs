using Microsoft.AspNetCore.Mvc;
using Zoo.BLL.DTOs.Volunteers;
using Zoo.BLL.Services.Interfaces;
using Zoo.DAL.Entity.HelpModels;
using Zoo.BLL.DTOs;
using System.Threading;
using VolunteerQueryParameters = Zoo.BLL.Services.VolunteerQueryParameters;

namespace Zoo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VolunteerController : ControllerBase
    {
        private readonly IVolunteerService _volunteerService;

        public VolunteerController(IVolunteerService volunteerService)
        {
            _volunteerService = volunteerService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<VolunteerReadDto>>> GetAll([FromQuery] VolunteerQueryParameters queryParameters, CancellationToken ct)
        {
            var result = await _volunteerService.GetPagedAsync(queryParameters, ct);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<VolunteerReadDto>> GetById(int id, CancellationToken ct)
        {
            var dto = await _volunteerService.GetByIdAsync(id, ct);
            return dto == null ? NotFound() : Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<VolunteerReadDto>> Create([FromBody] VolunteerCreateDto dto, CancellationToken ct)
        {
            var created = await _volunteerService.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<VolunteerReadDto>> Update(int id, [FromBody] VolunteerUpdateDto dto, CancellationToken ct)
        {
            if (id != dto.Id) return BadRequest("ID mismatch");
            var updated = await _volunteerService.UpdateAsync(id, dto, ct);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var deleted = await _volunteerService.DeleteAsync(id, ct);
            return deleted ? NoContent() : NotFound();
        }
    }
}