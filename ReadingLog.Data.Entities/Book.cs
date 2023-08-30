namespace ReadingLog.Data.Entities
{
    public class Book : BaseEntity
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
