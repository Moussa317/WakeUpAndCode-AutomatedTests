using ReadingLog.Core.Models;
using ReadingLog.Data;

namespace ReadingLog.Services;

public class BookSerivce : IBookService
{
    private readonly IBookDataService dataService;
    private readonly IIsbnWrapper isbnWrapper;

    public BookSerivce(IBookDataService dataService, IIsbnWrapper isbnWrapper)
    {
        this.dataService=dataService;
        this.isbnWrapper=isbnWrapper;
    }

    public async Task CreateBookAsync(BookCreationModel inputModel)
    {
        if(!await isbnWrapper.IsbnExistsAsync(inputModel.Isbn))
        {
            throw new ApplicationException($"The isbn number: {inputModel.Isbn} is invalid.");
        }

        await dataService.CreateBookAsync(inputModel);
    }
}

