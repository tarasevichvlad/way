using Domain.Cars;
using Domain.Reviews;
using Domain.Shared;
using Domain.Trips;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Persistence.Cars;
using Persistence.Reviews;
using Persistence.Trips;
using Persistence.Users;

namespace Persistence.Shared
{
    public sealed class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Trip> Trips { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new TripConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<T> GetDbSet<T>() where T : class, IEntity
        {
            return Set<T>();
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}