using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleTracking.Dll.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public string UserName  { get; set; }

    }
}
