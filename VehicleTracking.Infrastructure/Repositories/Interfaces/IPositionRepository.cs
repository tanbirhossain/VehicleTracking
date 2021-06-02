using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleTracking.Infrastructure.Domain.Entities;

namespace VehicleTracking.Infrastructure.Repositories.Interfaces
{
    public interface IPositionRepository
    {
        Task<Position> CurrentPositionByVehicleId(long vehicleId);
        Task<List<Position>> GetJourney(long vehicleId, DateTime startDate, DateTime endDate);
        Task<Position> InsertPosition(Position position);
    }
}
