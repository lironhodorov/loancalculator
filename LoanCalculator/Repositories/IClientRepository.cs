using LoanCalculator.Models;

namespace LoanCalculator.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAll();
        Task<Client> GetById(int clientId);
    }
}
