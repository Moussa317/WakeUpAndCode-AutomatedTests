using ReadingLog.Core.Enums;
using ReadingLog.Core.Models;
using ReadingLog.Data.Abstractions;
using ReadingLog.Data.Entities;
using System.Data.Entity;

namespace ReadingLog.Data;

public class ReviewDataService : IReviewDataService
{
    private readonly IUnitOfWork unitOfWork;

    public ReviewDataService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork=unitOfWork;
    }
    public async Task CreateReviewAsync(ReviewCreationInputModel inputModel)
    {
        var review = new Review
        {
            BookId = inputModel.BookId,
            Rating = inputModel.Rating,
            Thoughts = inputModel.Review
        };
        unitOfWork.Add(review);
        await unitOfWork.SaveAsync();
    }

    public async Task<List<ReviewModel>> GetReviewsAsync()
    {
        //TODO:: link to the repository instead
        return await unitOfWork.Query<Review>(c => c.IsDeleted == false).Select(review => new ReviewModel
        {
            BookId = review.BookId,
            Rating = review.Rating,
            Review = review.Thoughts
        }).ToListAsync();
    }
}
