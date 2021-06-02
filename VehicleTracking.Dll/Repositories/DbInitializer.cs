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

                // Look for any Client.
                if (context.Clients.Any())
                {
                    return;   // DB has been seeded

                }

                // client 
                // pass: 1234

                var client = new Client
                {
                    FirstName = "Mohammed",
                    LastName = "Tanbir",
                    Email = "ovibhuiyan43@gmail.com",
                    Password = "57a0f401fbbe2df3bd258d89e5a73808fa51a10d6a8188f90aab1a988770e4b7ef533198adb539547df8887bc743d6bc76fb6ab5a8ee67929834b4066d70df8e",
                    IsActive = true,
                    AddedBy = 0,
                    AddedDate = DateTime.UtcNow
                    
                };
                // vehicle
                var vehicle = new Vehicle
                {
                    DeviceId = "demodeviceId1",
                    Name = "Car"
                };
                // position
                var position = new Position
                {
                    Longitude = 10,
                    Latitude = 35.9,
                    AddedDate = DateTime.UtcNow
                };

                vehicle.Positions.Add(position);
                client.Vehicles.Add(vehicle);
                var result_client = context.Clients.Add(client);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(" >>>>  Exception Seed  <<<<<" + ex);
                throw;
            }
        }
    }
}
