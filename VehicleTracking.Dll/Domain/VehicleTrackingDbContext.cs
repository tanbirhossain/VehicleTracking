using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VehicleTracking.Infrastructure.Domain.Common;
using VehicleTracking.Infrastructure.Domain.Entities;
using VehicleTracking.Infrastructure.Repositories.Interfaces;

namespace VehicleTracking.Infrastructure.Domain
{
    public class VehicleTrackingDbContext : DbContext
    {
        private readonly IContextRepository _contextRepository;

        public VehicleTrackingDbContext(DbContextOptions options) : base(options)
        {
        }

        public VehicleTrackingDbContext(DbContextOptions options, IContextRepository contextRepository) : base(options)
        {
            _contextRepository = contextRepository;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VehicleTrackingDbContext).Assembly);
           
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");
            modelBuilder.Entity<Position>().ToTable("Position");
        }


       public virtual DbSet<Client> Clients{ get; set; }
       public virtual DbSet<Vehicle> Vehicles{ get; set; }
       public virtual DbSet<Position> Positions { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.AddedBy = _contextRepository.GetUserId();
                        entry.Entity.AddedDate = DateTime.UtcNow;
                        entry.Entity.IsActive = true;

                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _contextRepository.GetUserId();
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
