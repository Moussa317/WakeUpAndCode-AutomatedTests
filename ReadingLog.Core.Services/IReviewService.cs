using ReadingLog.Core.Models;

namespace ReadingLog.Services
{
    public interface IReviewService
    {
        Task<List<ReviewModel>> GetReviewsAsync();

        Task CreateReviewAsync(ReviewCreationInputModel inputModel);
    }
}
