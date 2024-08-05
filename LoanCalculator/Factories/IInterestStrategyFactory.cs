using LoanCalculator.Strategies;

namespace LoanCalculator.Factories
{
    public interface IInterestStrategyFactory
    {
        IInterestStrategy GetInterestStrategy(int age);
    }
}
