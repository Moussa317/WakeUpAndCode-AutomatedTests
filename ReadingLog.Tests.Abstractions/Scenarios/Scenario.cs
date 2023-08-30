using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using ReadingLog.Data.Abstractions;
using ReadingLog.Data.Entities;
using ReadingLog.Data.Repository;
using ReadingLog.Tests.Abstractions.Generators;
using ReadinngLog.Tests.Abstractions;

namespace ReadingLog.Tests.Abstractions.Scenarios
{
    public class Scenario : BaseTest
    {
        public IServiceProvider ServiceProvider { get; set; }

        public Dictionary<Type, object> Mocks { get; set; } = new();

        public List<Book> Books { get; set; } = new();

        public T GetService<T>() where T : class => ServiceProvider.GetService<T>();

        public T GetController<T>() where T : class => GetService<T>();

        public IUnitOfWork GetUnitOfWork() => GetService<IUnitOfWork>();

        public void AddMock<T>() where T : class
        {
            var mock = GenerateMock<T>();
            Mocks.Add(typeof(T), mock.Object);
        }

        public void AddMock<T>(Mock mock) where T : class
        {
            Mocks.Add(typeof(T), mock.Object);
        }

        public async Task<Book> AddBookAsync(Action<Book> action = null)
        {
            var unitOfWork = GetUnitOfWork();
            Book book = Faker.GenerateBook(action);

            await unitOfWork.AddAsync(book);
            await unitOfWork.SaveAsync();

            Books.Add(book);

            return book;
        }

        public void Init()
        {
            var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                //Replacing the db context
                builder.ConfigureTestServices(services =>
                {
                    var serviceProvider = services.BuildServiceProvider();
                    var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<RLDbContext>));
                    if (descriptor != null)
                        services.Remove(descriptor);

                    //TODO: replace the app settings with the test project's one.

                    //TODO: Get the connection string from the test project appsettings instead
                    services.AddDbContext<RLDbContext>(options =>
                                options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ReadingLogTests;Trusted_Connection=True;MultipleActiveResultSets=true"));

                    foreach (KeyValuePair<Type, object> mock in Mocks)
                    {
                        descriptor = services.SingleOrDefault(d => d.ServiceType == mock.Key);
                        if (descriptor != null)
                            services.Remove(descriptor);

                        services.AddSingleton(mock.Key, mock.Value);
                    }
                });
            });

            IServiceScope scope = factory.Server.Services.GetService<IServiceScopeFactory>().CreateScope();

            ServiceProvider = scope.ServiceProvider;
        }

    }

}
