using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleTracking.Infrastructure.Domain;
using VehicleTracking.Infrastructure.Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VehicleTracking.Infrastructure.Repositories.Interfaces;

namespace VehicleTracking.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly VehicleTrackingDbContext _db;

        public ClientRepository(VehicleTrackingDbContext db)
        {
            _db = db;
        }

        public async Task<Client> InsertClient(Client client)
        {
            var result = await _db.AddAsync(client);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Client> GetClientByEmail(string email)
        {
            var result = await _db.Clients.Where(e => e.Email == email).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<Client>> GetAllClients()
        {
            var result = await _db.Clients.ToListAsync();
            return result;
        }
    }
}
