using Domain;
using Moq;
using Services;
using Services.Interfaces;
using Heroes.Repository.Interfaces;
using Xunit;
using System.Threading.Tasks;

namespace Heroes.Tests.Services
{
    public class HeroPowerServiceTests
    {
        [Fact]
        public async Task AddAsync_ShouldCallRepositoryAddAsync()
        {
            // Arrange
            var mockRepo = new Mock<IHeroPowerRepository>();
            var service = new HeroPowerService(mockRepo.Object);
            var entity = new HeroPowerDomain { HeroeId = 1, PowerId = 2 };

            // Act
            await service.AddAsync(entity);

            // Assert
            mockRepo.Verify(r => r.AddAsync(entity), Times.Once);
        }
    }
}