using Microsoft.AspNetCore.Mvc;
using Zoo.BLL.DTOs.Volunteers;
using Zoo.BLL.Services.Interfaces;

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
        public async Task<ActionResult<IEnumerable<VolunteerReadDto>>> GetAll(CancellationToken ct)
        {
            var volunteers = await _volunteerService.GetAllAsync(ct);
            return Ok(volunteers);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<VolunteerReadDto>> GetById(int id, CancellationToken ct)
        {
            var volunteer = await _volunteerService.GetByIdAsync(id, ct);
            if (volunteer == null)
                return NotFound();
            return Ok(volunteer);
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
            if (id != dto.Id)
                return BadRequest("Id in URL and DTO must match.");

            var updated = await _volunteerService.UpdateAsync(id, dto, ct);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var deleted = await _volunteerService.DeleteAsync(id, ct);
            return deleted ? NoContent() : NotFound();
        }
    }
}
