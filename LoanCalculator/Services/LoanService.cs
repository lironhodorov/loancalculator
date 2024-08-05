using LoanCalculator.Factories;
using LoanCalculator.Models;
using LoanCalculator.Repositories;

namespace LoanCalculator.Services
{
    public class LoanService : ILoanService
    {
        private readonly IClientService _clientService;
        private readonly IInterestStrategyFactory _interestStrategyFactory;
        private readonly decimal primeInterest = 0.015m;

        public LoanService(IClientService clientService, IInterestStrategyFactory interestStrategyFactory)
        {
            _clientService = clientService;
            _interestStrategyFactory = interestStrategyFactory;
        }

        public async Task<LoanResponse> CalculateLoan(LoanRequest request)
        {
            var client = await _clientService.GetById(request.ClientId);
            if (client == null)
            {
                return null;
            }

            var interestStrategy = _interestStrategyFactory.GetInterestStrategy(client.Age);
            var response = interestStrategy.CalculateInterest(request.Amount, request.PeriodInMonths, primeInterest);

            return response;
        }
    }
}
