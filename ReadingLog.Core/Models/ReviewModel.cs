using ReadingLog.Core.Enums;

namespace ReadingLog.Core.Models
{
    public class ReviewModel
    {
        public string Review { get; set; }
        public BookRatings Rating { get; set; }
        public long BookId { get; set; }
    }
}
