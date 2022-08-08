using DatesHandling.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatesHandling.DataAccess.Interfaces
{
    public interface IDbContext : IDisposable
    {
        DbSet<Bar> Bars { get; }
        DbSet<Baz> Bazs { get; }
        DbSet<Foo> Foos { get; }

        int SaveChanges();
    }
}
