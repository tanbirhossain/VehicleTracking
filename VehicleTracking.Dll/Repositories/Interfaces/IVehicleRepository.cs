using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleTracking.Infrastructure.Domain.Entities;

namespace VehicleTracking.Infrastructure.Repositories.Interfaces
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicleByDeviceId(string deviceId);
        Task<List<Vehicle>> GetVehiclesByClientId(long clientId);
        Task<Vehicle> InsertVehicle(Vehicle vehicle);
        Task<bool> IsCorrectDevice(long clientId, string deviceId);
    }  
}
