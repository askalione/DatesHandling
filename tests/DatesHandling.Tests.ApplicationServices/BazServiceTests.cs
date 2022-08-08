using DatesHandling.ApplicationServices.Interfaces;
using DatesHandling.Tests.ApplicationServices.TestUtils;

namespace DatesHandling.Tests.ApplicationServices
{
    [Collection("ApplicationServices")]
    public class BazServiceTests
    {
        private readonly IBazService _service;

        public BazServiceTests()
        {
            var applicationServicesFixture = new ApplicationServicesFixture();
            _service = applicationServicesFixture.GetApplicationService<IBazService>();
        }

        [Fact]
        public void Create_Find()
        {
            // Arrange
            DateOnly date = DateOnly.FromDateTime(DateTime.Now);
            TimeOnly time = TimeOnly.FromDateTime(DateTime.Now);

            // Act
            BazDto createdBaz = _service.Create(date, time);
            BazDto? foundBaz = _service.Find(createdBaz.Id);

            // Assert
            foundBaz.Should().NotBeNull();
            foundBaz?.Date.Should().Be(date);
            foundBaz?.Time.Should().Be(time);
        }
    }
}
