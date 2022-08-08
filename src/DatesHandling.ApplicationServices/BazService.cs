using DatesHandling.ApplicationServices.Interfaces;
using DatesHandling.DataAccess.Interfaces;
using DatesHandling.Entities;

namespace DatesHandling.ApplicationServices
{
    internal class BazService : IBazService
    {
        private readonly IDbContext _dbContext;

        public BazService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BazDto Create(DateOnly date, TimeOnly time)
        {
            Baz baz = new Baz { Date = date, Time = time };

            _dbContext.Bazs.Add(baz);
            _dbContext.SaveChanges();

            return Map(baz);
        }

        public BazDto? Find(int id)
        {
            Baz? baz = _dbContext.Bazs
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (baz == null)
            {
                return null;
            }

            return Map(baz);
        }

        private BazDto Map(Baz baz)
            => new BazDto
            {
                Id = baz.Id,
                Date = baz.Date,
                Time = baz.Time
            };
    }
}
