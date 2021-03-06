using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VehicleTracking.Infrastructure.Domain.Common;

namespace VehicleTracking.Infrastructure.Domain.Entities
{
    public class Client : AuditableEntity
    {
        public Client()
        {
            this.Vehicles = new HashSet<Vehicle>();
        }


        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
       
    }
}
