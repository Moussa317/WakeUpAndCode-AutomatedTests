using Bogus;
using Moq;

namespace ReadinngLog.Tests.Abstractions
{
    public class BaseTest
    {
        public Faker Faker { get; } = new Faker();

        public DateTime UtcNow => DateTime.UtcNow;

        public Mock<T> GenerateMock<T>() where T : class => new Mock<T>();

    }
}
