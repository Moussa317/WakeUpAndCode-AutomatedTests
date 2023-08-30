using Bogus;
using ReadingLog.Data.Entities;

namespace ReadingLog.Tests.Abstractions.Generators
{
    public static class BookGenerator
    {
        public static Book GenerateBook(this Faker faker, Action<Book> action = null)
        {
            var book = new Book
            {
                ISBN = faker.Random.Hash(),
                CreatedAt = DateTime.UtcNow,
                Name = faker.Commerce.ProductName(),
            };

            action?.Invoke(book);
            return book;
        }
    }
}
