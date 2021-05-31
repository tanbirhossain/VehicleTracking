﻿using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");
            modelBuilder.Entity<Position>().ToTable("Position");
        }


       public DbSet<Client> Clients{ get; set; }
       public DbSet<Vehicle> Vehicles{ get; set; }
       public DbSet<Position> Positions { get; set; }
    }
}
