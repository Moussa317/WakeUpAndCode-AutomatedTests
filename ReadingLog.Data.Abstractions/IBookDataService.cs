using ReadingLog.Core.Models;

namespace ReadingLog.Data
{
    public interface IBookDataService
    {
        Task CreateBookAsync(BookCreationModel inputModel);
        
    }

}
