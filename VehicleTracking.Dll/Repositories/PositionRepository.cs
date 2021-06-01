using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracking.Infrastructure.Domain;
using VehicleTracking.Infrastructure.Domain.Entities;
using VehicleTracking.Infrastructure.Repositories.Interfaces;

namespace VehicleTracking.Infrastructure.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly VehicleTrackingDbContext _db;

        public PositionRepository(VehicleTrackingDbContext db)
        {
            _db = db;
        }

        public async Task<Position> InsertPosition(Position position)
        {
            var result = await _db.Positions.AddAsync(position);
            await _db.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<List<Position>> GetJourney(long vehicleId, DateTime startDate, DateTime endDate)
        {
            var result = await _db.Positions.Where(e => e.VehicleId == vehicleId && e.AddedDate >= startDate && e.AddedDate <= endDate).ToListAsync();
            return result;
        }
        public async Task<Position> CurrentPositionByVehicleId(long vehicleId)
        {
            var result = await _db.Positions.Where(e => e.VehicleId == vehicleId).OrderByDescending(e=>e.Id).FirstOrDefaultAsync();
            return result;
        }
    }
}
