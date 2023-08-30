using ReadingLog.Core.Enums;

namespace ReadingLog.Data.Entities
{
    public class Review : BaseEntity
    {
        public string Thoughts { get; set; }
        public BookRatings Rating { get; set; }
        public long BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
