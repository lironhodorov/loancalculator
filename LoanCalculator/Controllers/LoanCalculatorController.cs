using LoanCalculator.Models;
using LoanCalculator.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoanCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpPost]
        public async Task<IActionResult> CalculateLoan([FromBody] LoanRequest request)
        {
            if (request == null || request.Amount <= 0 || request.PeriodInMonths < 12)
            {
                return BadRequest("Invalid request.");
            }

            var response = await _loanService.CalculateLoan(request);
            return Ok(response);
        }
    }
}
