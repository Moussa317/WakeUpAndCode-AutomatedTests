using ReadingLog.Core.Models;

namespace ReadingLog.Services
{
    public interface IIsbnWrapper
    {
        Task<BookDetails> GetBookDetailsAsync(string isbn);

        Task<bool> IsbnExistsAsync(string isbn);
        Task<bool> IsBookNameValidAync(string name);
    }
}
