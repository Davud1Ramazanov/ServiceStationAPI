using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServiceStationAPI.Models;

namespace ServiceStationAPI.Configuration
{
    public class DbContextClass : IdentityDbContext<IdentityUser>
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
