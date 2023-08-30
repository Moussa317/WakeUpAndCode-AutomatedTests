using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework.Internal;
using ReadingLog.Controllers;
using ReadingLog.Services;
using ReadinngLog.Tests.Abstractions;

namespace ReadingLog.UnitTests.Services
{
    public class Tests : BaseTest
    {
        WeatherForecastController controller;
        ReviewController _reviewController;
        [SetUp]
        public void Setup()
        {
            var loggerMock = GenerateMock<ILogger<WeatherForecastController>>();
            controller = new WeatherForecastController(loggerMock.Object);
            _reviewController = new ReviewController(ServiceProvider.GetService<IReviewService>());
        }

        [Test]
        public async Task Test1()
        {
            controller.Get();

            var t = ServiceProvider.GetService<IReviewService>();

            var x = await _reviewController.GetReviews();

            Assert.Pass();
        }
    }
}