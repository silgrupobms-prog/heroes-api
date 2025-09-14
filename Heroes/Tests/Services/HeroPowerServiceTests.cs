using Domain;
using Moq;
using Services;
using Heroes.Repository.Interfaces;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Heroes.Tests.Services
{
    public class HeroPowerServiceTests
    {
        [Fact(DisplayName = "AddAsync should call AddAsync on repository once")]
        public async Task AddAsync_ShouldCallRepositoryAddAsync()
        {
            // Arrange: Create repository mock and service
            var mockRepo = new Mock<IHeroPowerRepository>();
            var service = new HeroPowerService(mockRepo.Object);
            var entity = new HeroPowerDomain { HeroeId = 1, PowerId = 2 };

            // Act: Call service method
            await service.AddAsync(entity);

            // Assert: Verify repository method was called once
            mockRepo.Verify(r => r.AddAsync(entity), Times.Once);
        }

        [Fact(DisplayName = "GetByHeroIdAsync should return list from repository")]
        public async Task GetByHeroIdAsync_ShouldReturnListFromRepository()
        {
            // Arrange: Setup repository mock to return expected list
            var mockRepo = new Mock<IHeroPowerRepository>();
            var expected = new List<HeroPowerDomain>
            {
                new HeroPowerDomain { HeroeId = 1, PowerId = 2 },
                new HeroPowerDomain { HeroeId = 1, PowerId = 3 }
            };
            mockRepo.Setup(r => r.GetByHeroIdAsync(1)).ReturnsAsync(expected);

            var service = new HeroPowerService(mockRepo.Object);

            // Act: Call service method
            var result = await service.GetByHeroIdAsync(1);

            // Assert: Check result and verify repository method was called once
            Assert.Equal(expected, result);
            mockRepo.Verify(r => r.GetByHeroIdAsync(1), Times.Once);
        }

        [Fact(DisplayName = "DeleteAsync should call DeleteAsync on repository once")]
        public async Task DeleteAsync_ShouldCallRepositoryDeleteAsync()
        {
            // Arrange: Create repository mock and service
            var mockRepo = new Mock<IHeroPowerRepository>();
            var service = new HeroPowerService(mockRepo.Object);

            // Act: Call service method
            await service.DeleteAsync(1, 2);

            // Assert: Verify repository method was called once
            mockRepo.Verify(r => r.DeleteAsync(1, 2), Times.Once);
        }
    }
}