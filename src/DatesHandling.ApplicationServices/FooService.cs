using DatesHandling.ApplicationServices.Interfaces;
using DatesHandling.DataAccess.Interfaces;
using DatesHandling.Entities;

namespace DatesHandling.ApplicationServices
{
    internal class FooService : IFooService
    {
        private readonly IDbContext _dbContext;

        public FooService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public FooDto Create(DateTime timestamp)
        {
            Foo foo = new Foo { Timestamp = timestamp };

            _dbContext.Foos.Add(foo);
            _dbContext.SaveChanges();

            return Map(foo);
        }

        public FooDto? Find(int id)
        {
            Foo? foo = _dbContext.Foos
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (foo == null)
            {
                return null;
            }

            return Map(foo);
        }

        private FooDto Map(Foo foo)
            => new FooDto
            {
                Id = foo.Id,
                Timestamp = foo.Timestamp
            };
    }
}
