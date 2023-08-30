using Bogus;
using ReadingLog.Core.Enums;
using ReadingLog.Core.Models;

namespace ReadingLog.Tests.Abstractions.Generators
{
    public static class ReviewModelGenerator
    {
        public static ReviewModel GenerateReviewModel(this Faker faker, Action<ReviewModel> action = null)
        {
            var model = new ReviewModel 
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
