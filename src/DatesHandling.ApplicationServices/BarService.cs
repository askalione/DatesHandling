using DatesHandling.ApplicationServices.Interfaces;
using DatesHandling.DataAccess.Interfaces;
using DatesHandling.Entities;

namespace DatesHandling.ApplicationServices
{
    internal class BarService : IBarService
    {
        private readonly IDbContext _dbContext;

        public BarService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BarDto Create(DateTime timestamptz)
        {
            Bar bar = new Bar { Timestamptz = timestamptz };

            _dbContext.Bars.Add(bar);
            _dbContext.SaveChanges();

            return Map(bar);
        }

        public BarDto? Find(int id)
        {
            Bar? bar = _dbContext.Bars
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (bar == null)
            {
                return null;
            }

            return Map(bar);
        }

        private BarDto Map(Bar bar)
            => new BarDto
            {
                Id = bar.Id,
                Timestamptz = bar.Timestamptz
            };
    }
}
