using Hospital_Management_System.Models.DTOs.Billing;
//using Hospital_Management_System.Services.Billing;
using Hospital_Management_System.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class BillingController : ControllerBase
    {
        private readonly IBillingService _billingService;

        public BillingController(IBillingService billingService)
        {
            _billingService = billingService;
        }

        // allow all roles to view bills
        [HttpGet]
        [Authorize(Roles = "Admin,Accountant,Doctor,Reception")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _billingService.GetAllAsync();
            return Ok(result);
        }

        // allow all roles to view bills
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Accountant,Doctor,Reception")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _billingService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // only Admin + Accountant can create
        [HttpPost]
        [Authorize(Roles = "Admin,Accountant")]
        public async Task<IActionResult> Create([FromBody] BillingCreateDto dto)
        {
            var result = await _billingService.CreateAsync(dto);
            return Ok(result);
        }

        // only Admin + Accountant can update
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Accountant")]
        public async Task<IActionResult> Update(int id, [FromBody] BillingUpdateDto dto)
        {
            var result = await _billingService.UpdateAsync(id, dto);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // only Admin can delete
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _billingService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return Ok(new { message = "Deleted Successfully" });
        }
    }
}
