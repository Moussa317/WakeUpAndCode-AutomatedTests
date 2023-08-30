using ReadingLog.Services;
using ReadingLog.Tests.Abstractions.Scenarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingLog.IntegrationTests.Services
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class ReviewServiceTests
    {
        [Test]
        public async Task Review() 
        {
            // Arrange
            var scenario = new Scenario();
            scenario.Init();

            var service = scenario.GetService<IReviewService>();
            //Act
            await service.CreateReviewAsync(new Core.Models.ReviewCreationInputModel());
            var result = await service.GetReviewsAsync();

            //Assert
            Assert.That(result,Is.Not.Null);
        }
    }
}
