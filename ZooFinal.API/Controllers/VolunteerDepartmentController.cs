using Microsoft.AspNetCore.Mvc;
using Zoo.BLL.DTOs.VolunteersDepartment;
using Zoo.BLL.Services.Interfaces;

namespace Zoo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VolunteerDepartmentController : ControllerBase
    {
        private readonly IVolunteersDepartmentService _departmentService;

        public VolunteerDepartmentController(IVolunteersDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VolunteersDepartmentReadDto>>> GetAll(CancellationToken ct)
        {
            var departments = await _departmentService.GetAllAsync(ct);
            return Ok(departments);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<VolunteersDepartmentReadDto>> GetById(int id, CancellationToken ct)
        {
            var department = await _departmentService.GetByIdAsync(id, ct);
            if (department == null)
                return NotFound();
            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult<VolunteersDepartmentReadDto>> Create([FromBody] VolunteersDepartmentCreateDto dto, CancellationToken ct)
        {
            var created = await _departmentService.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<VolunteersDepartmentReadDto>> Update(int id, [FromBody] VolunteersDepartmentUpdateDto dto, CancellationToken ct)
        {
            if (id != dto.Id)
                return BadRequest("Id in URL and DTO must match.");

            var updated = await _departmentService.UpdateAsync(id, dto, ct);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var deleted = await _departmentService.DeleteAsync(id, ct);
            return deleted ? NoContent() : NotFound();
        }
    }
}
