using Moq;
using Services;
using Heroes.Repository.Interfaces;
using Xunit;
using System.Threading.Tasks;

namespace Heroes.Tests.Services
{
    public class DeleteHeroeServiceTests
    {
        [Fact(DisplayName = "DeleteAsync should call DeleteAsync on repository once")]
        public async Task DeleteAsync_ShouldCallRepositoryDeleteAsync()
        {
            // Arrange
            var mockRepo = new Mock<IHeroesRepository>();
            var service = new DeleteHeroeService(mockRepo.Object);

            // Act
            await service.Perform(1);

            // Assert
            mockRepo.Verify(r => r.DeleteAsync(1), Times.Once);
        }
    }
}