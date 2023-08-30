using ReadingLog.Core.Models;

namespace ReadingLog.Services
{
    public class IsbnWrapper : IIsbnWrapper
    {
        public async Task<BookDetails> GetBookDetailsAsync(string isbn)
        {
            //Call the ISBN api to get details
            await Task.Delay(10);
            return new BookDetails();
        }

        public Task<bool> IsbnExistsAsync(string isbn)
        {
            return Task.FromResult(true);
        }

        public Task<bool> IsBookNameValidAync(string name)
        {
            return Task<bool>.FromResult(true);
        }
    }
}
