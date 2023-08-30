using ReadingLog.Core.Enums;

namespace ReadingLog.Core.Models;

public class ReviewCreationInputModel
{
    public long BookId { get; set; }

    public string Review { get; set; }

    public BookRatings Rating { get; set; }
}
