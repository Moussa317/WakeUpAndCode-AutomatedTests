using Bogus;
using ReadingLog.Core.Enums;
using ReadingLog.Core.Models;

namespace ReadingLog.Tests.Abstractions.Generators
{
    public static class ReviewCreationInputModelGenerator
    {
        public static ReviewCreationInputModel GenerateReviewCreationInputModel(this Faker faker, Action<ReviewCreationInputModel> action = null)
        {
            var model = new ReviewCreationInputModel
            {
                BookId = faker.Random.Int(min: 1),
                Rating = faker.PickRandom<BookRatings>(),
                Review = faker.Random.Words()
            };

            action?.Invoke(model);
            return model;
        }
    }
}
