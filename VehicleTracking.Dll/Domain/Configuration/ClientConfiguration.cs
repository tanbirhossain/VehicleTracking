using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleTracking.Infrastructure.Domain.Entities;

namespace VehicleTracking.Infrastructure.Domain.Configuration
{
   
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(p => p.FirstName)
                .HasMaxLength(100);
              
            
        }
    }
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(200);



            builder.HasOne(d => d.Client)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Vehicle_Client");
        }
    }
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {

            builder.HasOne(d => d.Vehicle)
                 .WithMany(p => p.Positions)
                 .HasForeignKey(d => d.VehicleId)
                 .HasConstraintName("FK_Position_Vehicle");
        }
    }
}
