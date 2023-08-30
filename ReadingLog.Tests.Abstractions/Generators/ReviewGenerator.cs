using Bogus;
using ReadingLog.Core.Enums;
using ReadingLog.Data.Entities;

namespace ReadingLog.Tests.Abstractions.Generators
{
    public static class ReviewGenerator
    {
        public static Review GenerateReview(this Faker faker, Action<Review> action = null)
        {
            var book = faker.GenerateBook();
            return faker.GenerateReview(book, action);
        }

        public static Review GenerateReview(this Faker faker, Book book, Action<Review> action = null)
        {
            var review = new Review
            {
                Book = book,
                Rating = faker.PickRandom<BookRatings>(),
                Thoughts = faker.Random.Words(10),
            };

            action?.Invoke(review);
            return review;
        }
    }
}
