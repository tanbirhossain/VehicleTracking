using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleTracking.Infrastructure.Domain.Entities
{
    public class Vehicle
    {
        public Vehicle()
        {
            this.Positions = new HashSet<Position>();
        }
        public long Id { get; set; }
        public long ClientId { get; set; }
        public string DeviceId { get; set; }
        public string Name { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<Position> Positions { get; set; }

    }
}
