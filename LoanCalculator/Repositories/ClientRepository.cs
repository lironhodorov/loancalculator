using LoanCalculator.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculator.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly string path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "clients.json");

        public async Task<IEnumerable<Client>> GetAll()
        {
            using (var reader = new StreamReader(path))
            {
                var json = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<List<Client>>(json);
            }
        }

        public async Task<Client> GetById(int clientId)
        {
            var clients = await GetAll();
            return clients.FirstOrDefault(c => c.Id == clientId);
        }
    }
}
