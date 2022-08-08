using DatesHandling.ApplicationServices.Interfaces;
using DatesHandling.Tests.ApplicationServices.TestUtils;
using Microsoft.EntityFrameworkCore;

namespace DatesHandling.Tests.ApplicationServices
{
    [Collection("ApplicationServices")]
    public class BarServiceTests
    {
        private readonly IBarService _service;

        public BarServiceTests()
        {
            var applicationServicesFixture = new ApplicationServicesFixture();
            _service = applicationServicesFixture.GetApplicationService<IBarService>();
        }

        [Fact]
        public void Create_Find()
        {
            // Arrange
            DateTime timestamp = DateTime.UtcNow;

            // Act
            BarDto createdBar = _service.Create(timestamp);
            BarDto? foundBar = _service.Find(createdBar.Id);

            // Assert
            foundBar.Should().NotBeNull();
            foundBar?.Timestamptz.Should().BeCloseTo(timestamp, TimeSpan.FromTicks(10));
        }

        [Fact]
        public void Create_throws_if_timestamp_is_local()
        {
            // Arrange
            DateTime timestamp = DateTime.Now;

            // Act
            Action act = () => _service.Create(timestamp);

            // Assert
            act.Should().ThrowExactly<DbUpdateException>();
        }
    }
}
