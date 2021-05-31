using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleTracking.Infrastructure.Domain;
using VehicleTracking.Infrastructure.Domain.Entities;

namespace VehicleTracking.Infrastructure.Repositories
{
    public static class DbInitializer
    {
        public static void Initialize(VehicleTrackingDbContext context)
        {


            try
            {
                context.Database.EnsureCreated();

                // Look for any students.
                if (context.Clients.Any())
                {
                    return;   // DB has been seeded

                }

                // client
                var clients = new List<Client>
                {
                    new Client
                    {
                        FirstName = "Mohammed",
                        LastName = "Tanbir",
                        Email="ovibhuiyan43@gmail.com",
                        Password  = "57a0f401fbbe2df3bd258d89e5a73808fa51a10d6a8188f90aab1a988770e4b7ef533198adb539547df8887bc743d6bc76fb6ab5a8ee67929834b4066d70df8e"
                    }
                };

                context.Clients.AddRange(clients);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(" >>>>  EXception  <<<<<" + ex);
                throw;
            }
        }
    }
}
