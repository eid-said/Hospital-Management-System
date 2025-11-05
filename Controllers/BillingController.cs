using Hospital_Management_System.Models;
using Hospital_Management_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _billingService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var bill = await _billingService.GetByIdAsync(id);
            if (bill == null)
                return NotFound();

            return Ok(bill);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Billing billing)
        {
            var newBill = await _billingService.CreateAsync(billing);
            return Ok(newBill);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Billing billing)
        {
            if (id != billing.Id)
                return BadRequest();

            var updated = await _billingService.UpdateAsync(billing);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _billingService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return Ok();
        }
    }
}
