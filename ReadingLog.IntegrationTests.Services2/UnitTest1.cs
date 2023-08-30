using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using ReadingLog.Controllers;
using ReadingLog.Data;
using ReadingLog.Data.Entities;
using ReadingLog.Data.Repository;
using ReadingLog.Services;
using ReadingLog.Tests.Abstractions.Generators;
using ReadingLog.Tests.Abstractions.Scenarios;
using ReadinngLog.Tests.Abstractions;
using System.Security.Authentication.ExtendedProtection;

namespace ReadingLog.IntegrationTests.Services2
{
    public class Tests : BaseTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task Test1()
        {
            //Arrange
            Scenario scenario = new Scenario();

            var mock = GenerateMock<IIsbnWrapper>();
            mock.Setup(s => s.IsbnExistsAsync(It.IsAny<string>())).ReturnsAsync(false);

            scenario.AddMock<IIsbnWrapper>(mock);

            scenario.Init();

            await scenario.AddBookAsync(a =>
            {
                a.ISBN = "317";
            });

            var book =  scenario.Books.First(a=>a.ISBN == "317");

            var service = scenario.GetService<IReviewService>();
            var unitOfWork = scenario.GetUnitOfWork();

            var inmputModel = Faker.GenerateReviewCreationInputModel(a=>a.BookId = book.Id);

            //Act
            await service.CreateReviewAsync(inmputModel);
           
            //Assert
            var createdReview = await unitOfWork.FirstOrDefaultAsync<Review>(a=>a.BookId == book.Id);

            Assert.That(createdReview, Is.Not.Null);
            Assert.That(createdReview.Rating, Is.EqualTo(inmputModel.Rating));
            Assert.That(createdReview.Thoughts, Is.EqualTo(inmputModel.Review));

            Assert.Pass();

        }
    }
}