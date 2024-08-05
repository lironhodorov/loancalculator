using LoanCalculator.Models;

namespace LoanCalculator.Strategies
{
    public interface IInterestStrategy
    {
        LoanResponse CalculateInterest(decimal amount, int periodInMonths, decimal primeInterest);
    }
}
