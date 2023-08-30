using ReadingLog.Core.Models;

namespace ReadingLog.Data
{
    public interface IReviewDataService
    {
        Task<List<ReviewModel>> GetReviewsAsync();
        Task CreateReviewAsync(ReviewCreationInputModel inputModel);
    }

}
