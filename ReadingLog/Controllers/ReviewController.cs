using Microsoft.AspNetCore.Mvc;
using ReadingLog.Core.Models;
using ReadingLog.Services;
using ReadingLog.ViewModel;

namespace ReadingLog.Controllers
{
    [ApiController]
    [Route("reviews")]
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this.reviewService=reviewService;
        }

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View("TestView", new ReviewInputModel
        //    {
        //        BookId = 333,
        //    });
        //}

        [HttpGet]
        public async Task<IActionResult> GetReviews()
        {
            List<ReviewModel> items = await reviewService.GetReviewsAsync();

            return Ok(items);
        }

        //[HttpGet("create/review")]
        //public IActionResult CreateReview(long bookId)
        //{
        //    return View();
        //}

        [HttpPost("create")]
        public async Task<IActionResult> CreateReview(ReviewInputModel inputModel)
        {
            try
            {
                await reviewService.CreateReviewAsync(new ReviewCreationInputModel
                {
                    BookId = inputModel.BookId,
                    Rating = inputModel.Rating,
                    Review = inputModel.Review,

                });

                return Ok();
            }
            catch (Exception e)
            {

                return RedirectToAction(nameof(CreateReview), new { bookId = inputModel.BookId });
            }
        }
    }
}
