using ReadingLog.Core.Enums;
using ReadingLog.Core.Models;

namespace ReadingLog.Data
{
    public class ReviewDataService : IReviewDataService
    {
        public Task CreateReviewAsync(ReviewCreationInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ReviewModel>> GetReviewsAsync()
        {
            //TODO:: link to the repository instead
            return new List<ReviewModel> {
                new ReviewModel
                {
                    BookId = 1,
                    Rating = BookRatings.OneStar,
                    Review = "Splendid review"

                }
            };
        }
    }
}
