using LoanCalculator.Models;
using LoanCalculator.Repositories;

namespace LoanCalculator.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task<Client> GetById(int clientId)
        {
            return _clientRepository.GetById(clientId);
        }
    }
}
