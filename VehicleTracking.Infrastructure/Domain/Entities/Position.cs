using System;
using VehicleTracking.Infrastructure.Domain.Common;

namespace VehicleTracking.Infrastructure.Domain.Entities
{
    public class Position : AuditableEntity
    {
        public long Id { get; set; }
        public long VehicleId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
