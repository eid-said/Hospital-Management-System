using Hospital_Management_System.Services;
using Hospital_Management_System.ViewModels.Department;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]


    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentResponseDto>>> GetAll()
        {
            var result = await _departmentService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentResponseDto>> Get(int id)
        {
            var dept = await _departmentService.GetByIdAsync(id);
            if (dept == null) return NotFound();

            return Ok(dept);
        }

        [HttpPost]
        public async Task<ActionResult<DepartmentResponseDto>> Create(DepartmentCreateDto dto)
        {
            var newDept = await _departmentService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = newDept.Id }, newDept);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DepartmentUpdateDto dto)
        {
            var updated = await _departmentService.UpdateAsync(id, dto);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _departmentService.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
