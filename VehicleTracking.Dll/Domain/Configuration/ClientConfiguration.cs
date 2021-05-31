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
}
