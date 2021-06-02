using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleTracking.Infrastructure.Domain.Entities;

namespace VehicleTracking.Infrastructure.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAllClients();
        Task<Client> GetClientByEmail(string email);
        Task<Client> GetClientById(long Id);
        Task<Client> InsertClient(Client client);
        Task<Client> UpdateClient(Client client);
    }
}
