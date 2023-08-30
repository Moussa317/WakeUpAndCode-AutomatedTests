using ReadingLog.Core.Models;
using ReadingLog.Data;

namespace ReadingLog.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewDataService reviewDataService;
    private readonly IIsbnWrapper isbnWrapper;

    public ReviewService(IReviewDataService reviewDataService, IIsbnWrapper isbnWrapper)
    {
        this.reviewDataService=reviewDataService;
        this.isbnWrapper=isbnWrapper;
    }

    public async Task CreateReviewAsync(ReviewCreationInputModel inputModel)
    {

        //do something with data

        await reviewDataService.CreateReviewAsync(inputModel);
    }

    public Task<List<ReviewModel>> GetReviewsAsync()
    {
        return reviewDataService.GetReviewsAsync();
    }
}

