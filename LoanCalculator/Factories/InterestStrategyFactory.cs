using LoanCalculator.Strategies;

namespace LoanCalculator.Factories
{
    public class InterestStrategyFactory : IInterestStrategyFactory
    {
        public IInterestStrategy GetInterestStrategy(int age)
        {
            if (age < 20)
            {
                return new YoungInterestStrategy();
            }
            else if (age >= 20 && age <= 35)
            {
                return new MiddleAgeInterestStrategy();
            }
            else
            {
                return new OldInterestStrategy();
            }
        }
    }
}
