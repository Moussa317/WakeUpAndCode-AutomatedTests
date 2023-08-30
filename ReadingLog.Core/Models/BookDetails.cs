namespace ReadingLog.Core.Models
{
    public class BookDetails
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
