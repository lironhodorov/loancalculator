using LoanCalculator.Models;

namespace LoanCalculator.Services
{
    public interface ILoanService
    {
        Task<LoanResponse> CalculateLoan(LoanRequest request);
    }
}
