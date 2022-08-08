using DatesHandling.DataAccess.Interfaces;
using DatesHandling.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatesHandling.DataAccess.PostgreSql
{
    public class AppDbContext : DbContext, IDbContext
    {
        public DbSet<Bar> Bars { get; private set; } = default!;
        public DbSet<Baz> Bazs { get; private set; } = default!;
        public DbSet<Foo> Foos { get; private set; } = default!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
