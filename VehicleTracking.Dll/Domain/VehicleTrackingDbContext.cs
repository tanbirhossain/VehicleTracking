using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleTracking.Infrastructure.Domain.Entities;

namespace VehicleTracking.Infrastructure.Domain
{
    public class VehicleTrackingDbContext : DbContext
    {
        public VehicleTrackingDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VehicleTrackingDbContext).Assembly);
           
            modelBuilder.Entity<Client>().ToTable("Client");
        }


       public DbSet<Client> Clients{ get; set; }
    }
}
