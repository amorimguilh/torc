using Microsoft.Extensions.Logging;
using Torc.API.Mappers.Interfaces;
using Torc.API.Repositories.Domain.DTOs;
using Torc.API.Repositories.Domain.Enums;
using Torc.API.Repositories.Interfaces;
using Torc.API.Services.Interfaces;

namespace Torc.API.Services;

public class BookSearchService : IBookSearchService
{
    private readonly IBookRepository _bookRepository;
    private readonly IBookMapper _bookMapper;
    private readonly ILogger<BookSearchService> _logger;

    public BookSearchService(IBookRepository bookRepository, IBookMapper bookMapper, ILogger<BookSearchService> logger)
    {
        _bookMapper = bookMapper;
        _bookRepository = bookRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<BookDto>> SearchAsync(string searchTerm, SearchType searchType, int skip = 0, int top = 10)
    {
        _logger.LogInformation("entering service layer to retrieve the books");
        var bookModels = await _bookRepository.SearchBooksAsync(searchTerm, searchType, skip, top);
        return _bookMapper.ToDto(bookModels);
    }
}
