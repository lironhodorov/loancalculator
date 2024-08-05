using LoanCalculator.Models;

namespace LoanCalculator.Strategies
{
    public class YoungInterestStrategy : IInterestStrategy
    {
        const decimal baseInterest = 0.02m;
        const int minimumPeriodInMonths = 12;
        const decimal extraPeriodInterestPrecentageForOneMonth = 0.0015m;
        public LoanResponse CalculateInterest(decimal amount, int periodInMonths, decimal primeInterest)
        {
            LoanResponse response = new LoanResponse();
            var baseInterestPrecentage = baseInterest + primeInterest;
            var extraPeriodInMonths = periodInMonths - minimumPeriodInMonths;
            var extraPeriodInterestPrecentage = (extraPeriodInMonths) * extraPeriodInterestPrecentageForOneMonth;
            var totalInterestPrecentage = baseInterestPrecentage + extraPeriodInterestPrecentage;

            var amountAfterBaseInterest = amount * baseInterestPrecentage;
            var amountAfterExtraPeriodInterest = amount * extraPeriodInterestPrecentage;

            var totalAmount = amount + amountAfterBaseInterest + amountAfterExtraPeriodInterest;

            response.BaseInterestPrecentage = baseInterestPrecentage;
            response.ExtraPeriodInterestPrecentage = extraPeriodInterestPrecentage;
            response.BaseTotalAmount = amountAfterBaseInterest;
            response.ExtraPeriodTotalAmount = amountAfterExtraPeriodInterest;
            response.ExtraPeriod = extraPeriodInMonths;
            response.TotalAmount = totalAmount;

            return response;
        }
    }
}
