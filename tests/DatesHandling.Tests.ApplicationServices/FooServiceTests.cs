using DatesHandling.ApplicationServices.Interfaces;
using DatesHandling.Tests.ApplicationServices.TestUtils;
using Microsoft.EntityFrameworkCore;

namespace DatesHandling.Tests.ApplicationServices
{
    [Collection("ApplicationServices")]
    public class FooServiceTests
    {
        private readonly IFooService _service;

        public FooServiceTests()
        {
            var applicationServicesFixture = new ApplicationServicesFixture();
            _service = applicationServicesFixture.GetApplicationService<IFooService>();
        }

        [Fact]
        public void Create_Find()
        {
            // Arrange
            DateTime timestamp = DateTime.Now;

            // Act
            FooDto createdFoo = _service.Create(timestamp);
            FooDto? foundFoo = _service.Find(createdFoo.Id);

            // Assert
            foundFoo.Should().NotBeNull();
            foundFoo?.Timestamp.Should().BeCloseTo(timestamp, TimeSpan.FromTicks(10));
        }

        [Fact]
        public void Create_throws_if_timestamp_is_utc()
        {
            // Arrange
            DateTime timestamp = DateTime.UtcNow;

            // Act
            Action act = () => _service.Create(timestamp);

            // Assert
            act.Should().ThrowExactly<DbUpdateException>();
        }
    }
}
