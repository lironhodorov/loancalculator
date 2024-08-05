using LoanCalculator.Models;

namespace LoanCalculator.Services
{
    public interface IClientService
    {
        Task<Client> GetById(int clientId);
    }
}