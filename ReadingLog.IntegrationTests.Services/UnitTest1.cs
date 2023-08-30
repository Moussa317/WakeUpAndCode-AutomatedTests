using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using ReadingLog.Controllers;
using ReadingLog.Core.Models;
using ReadingLog.Data;
using ReadingLog.Data.Repository;
using ReadingLog.Services;
using ReadingLog.Tests.Abstractions.Scenarios;
using ReadinngLog.Tests.Abstractions;

namespace ReadingLog.IntegrationTests.Services
{
    public class Tests : BaseTest
    {
        private WebApplicationFactory<Program> factory;
        private IServiceProvider serviceProvider;

        [SetUp]
        public void Setup()
        {
            factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                //Replacing the db context
                builder.ConfigureTestServices(services =>
                {
                    var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<RLDbContext>));
                    if (descriptor != null)
                        services.Remove(descriptor);


                    //var sp = services.BuildServiceProvider();
                    //var config = sp.GetRequiredService<IConfiguration>();
                    //var connectionString = config["ConnectionStrings.Default"];
                    //var serverVersion = ServerVersion.AutoDetect(connectionString);

                    //services.AddDbContext<ApplicationDbContext>(dbContextOptions =>
                    //    dbContextOptions
                    //        .UseMySql(connectionString, serverVersion)


                    services.AddDbContext<RLDbContext>(options =>
                    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ReadingLogTests;Trusted_Connection=True;MultipleActiveResultSets=true"));
            });
            });
           

        }

        [Test]
        public async Task Test1()
        {
            var fact = new WebApplicationFactory<Program>();
            var scope = fact.Server.Services.GetService<IServiceScopeFactory>().CreateScope();

            IServiceProvider serviceProvider= scope.ServiceProvider;

            var t = serviceProvider.GetService<IReviewService>();
            await t.CreateReviewAsync(new ReviewCreationInputModel());

            //using var scope = factory.Server.Services.GetService<IServiceScopeFactory>().CreateScope();
            //serviceProvider = scope.ServiceProvider;
            //var projectDir = Directory.GetCurrentDirectory();
            //var configPath = Path.Combine(projectDir, "appsettings.json");

            //var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            //{
            //    //TODO:: find a way to get connection string from appsettings
            //    //builder.ConfigureAppConfiguration((a, b) =>
            //    //{
            //    //    b.AddJsonFile(configPath);

            //    //});
            //    builder.ConfigureTestServices(services =>
            //    {
            //        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<RLDbContext>));
            //        if (descriptor != null)
            //            services.Remove(descriptor);


            //        services.AddDbContext<RLDbContext>(options =>
            //            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ReadingLogTests;Trusted_Connection=True;MultipleActiveResultSets=true"));
            //    });
            //});
            //        using var scope = factory.Server.Services
            //.GetService<IServiceScopeFactory>().CreateScope();
            //var service = serviceProvider.GetService<ReviewController>();

            //var t = await service.CreateReview(new ViewModel.ReviewInputModel());
            //await service.CreateReviewAsync(new Core.Models.ReviewCreationInputModel());

            Scenario scenario = new();
            //var mock = GenerateMock<IReviewDataService>();
            //mock.Setup(a => a.GetReviewsAsync()).ReturnsAsync(new List<ReviewModel> { new ReviewModel { BookId = 312 } });
            //scenario.AddMock<IReviewDataService>(mock);
            scenario.Init();

            var b = await scenario.AddBookAsync();

            //var x = scenario.ServiceProvider.GetService<IReviewService>();
            var service = scenario.GetService<ReviewController>();
            //var t = await service.CreateReview(new ViewModel.ReviewInputModel());
            //var l = await service.GetReviews();

            //mock.Verify(m=>m.GetReviewsAsync(),times:Times.Once);

            Assert.Pass();
        }
    }
}