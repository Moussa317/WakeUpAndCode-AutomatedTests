using ReadingLog.Core.Enums;

namespace ReadingLog.ViewModel
{
    public class ReviewInputModel
    {
        public long BookId { get; set; }

        public string Review { get; set; }

        public BookRatings Rating { get; set; }
    }
}
