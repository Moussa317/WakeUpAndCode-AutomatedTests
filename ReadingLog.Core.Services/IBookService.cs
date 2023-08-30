using ReadingLog.Core.Models;

namespace ReadingLog.Services
{
    public interface IBookService
    {
        Task CreateBookAsync(BookCreationModel inputModel);
    }
}
