using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleTracking.Dll.Domain.Entities;

namespace VehicleTracking.Dll.Domain
{
   public class VehicleTrackingDbContext : DbContext
    {
        public VehicleTrackingDbContext (DbContextOptions options) : base(options)
        {
        }

        DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
        }

    }
}
