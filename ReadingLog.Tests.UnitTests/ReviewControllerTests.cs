using Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ReadingLog.Controllers;
using ReadingLog.Core.Models;
using ReadingLog.Services;
using ReadingLog.ViewModel;
using ReadingLog.Tests.Abstractions.Generators;

namespace ReadingLog.Tests.UnitTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class ReviewControllerTests
    {
        private ReviewController reviewController;
        private Mock<IReviewService> reviewServiceMock;
        private Faker faker;

        [SetUp]
        public void SetUp()
        {
            reviewServiceMock = new Mock<IReviewService>();
            reviewController = new ReviewController(reviewServiceMock.Object);
            faker = new Faker();
        }

        [Test]
        public void GetIndex_AllGoesWell_ReturnView()
        {
            // Arrange


            // Act
            IActionResult result = reviewController.Index();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = (ViewResult)result;
            Assert.That(viewResult.ViewName, Is.EqualTo("TestView"));
            Assert.That(viewResult.Model, Is.Not.Null);
            Assert.That(viewResult.Model, Is.InstanceOf<ReviewInputModel>());
            var viewModel = (ReviewInputModel)viewResult.Model;
            Assert.That(viewModel.BookId, Is.EqualTo(333));
        }

        [Test]
        public async Task GetReviews_NoExistingReviews_GetsAnEmptyList()
        {
            //Arrange
            var reviewModels = new List<ReviewModel>
            {
                faker.GenerateReviewModel(a=>a.Review = "Ozbul tests"),
                faker.GenerateReviewModel(),
                faker.GenerateReviewModel(),
                faker.GenerateReviewModel()
            };

            ReviewCreationInputModel paramTest;

            reviewServiceMock.Setup(s => s.GetReviewsAsync()).ReturnsAsync(reviewModels);
            reviewServiceMock.Setup(s => s.CreateReviewAsync(It.IsAny<ReviewCreationInputModel>())).Callback<ReviewCreationInputModel>(a=> { paramTest = a; });

            //reviewServiceMock.Verify(s => s.CreateReviewAsync(It.Is<ReviewCreationInputModel>(a=>a.BookId == 1)), Times.Once);
            

            //Act
            IActionResult result = await reviewController.GetReviews();

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okObjectResult = (OkObjectResult)result;
            Assert.That(okObjectResult.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
            Assert.That(okObjectResult.Value, Is.Not.Null);
            Assert.That(okObjectResult.Value, Is.InstanceOf<List<ReviewModel>>());
            var okObjectResultValue = (List<ReviewModel>)okObjectResult.Value;
            Assert.That(okObjectResultValue.Count, Is.EqualTo(reviewModels.Count));

            foreach (ReviewModel model in okObjectResultValue)
            {
                var temp = reviewModels.FirstOrDefault(c => c.BookId == model.BookId);
                Assert.That(temp, Is.Not.Null);
                Assert.That(temp.Rating, Is.EqualTo(model.Rating));
                Assert.That(temp.Review, Is.EqualTo(model.Review));

            }

        }
    }
}
