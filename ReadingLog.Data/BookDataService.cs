using ReadingLog.Core.Models;
using ReadingLog.Data.Abstractions;
using ReadingLog.Data.Entities;

namespace ReadingLog.Data;

public class BookDataService : IBookDataService
{
    private readonly IUnitOfWork unitOfWork;

    public BookDataService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork=unitOfWork;
    }

    public async Task CreateBookAsync(BookCreationModel inputModel)
    {
        var book = new Book
        {
            ISBN = inputModel.Isbn,
            Name = inputModel.Name,
        };

        await unitOfWork.AddAsync(book);
        await unitOfWork.SaveAsync();

    }
}
