using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTracking.Infrastructure.Domain;
using VehicleTracking.Infrastructure.Domain.Entities;
using VehicleTracking.Infrastructure.Repositories.Interfaces;

namespace VehicleTracking.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehicleTrackingDbContext _db;

        public VehicleRepository(VehicleTrackingDbContext db)
        {
            _db = db;
        }

        public async Task<Vehicle> InsertVehicle(Vehicle vehicle)
        {
            var result = await _db.Vehicles.AddAsync(vehicle);
            await _db.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<List<Vehicle>> GetVehiclesByClientId(long clientId)
        {
            var result = await _db.Vehicles.Where(e=>e.ClientId == clientId).ToListAsync();
            return result;
        }

        public async Task<Vehicle> GetVehicleByDeviceId(string deviceId)
        {
            var result = await _db.Vehicles.Where(e=>e.DeviceId == deviceId).FirstOrDefaultAsync();
            return result;
        }
    }
}
