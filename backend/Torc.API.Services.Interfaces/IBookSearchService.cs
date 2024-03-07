using Torc.API.Repositories.Domain.DTOs;
using Torc.API.Repositories.Domain.Enums;

namespace Torc.API.Services.Interfaces;

public interface IBookSearchService
{
    Task<IEnumerable<BookDto>> SearchAsync(string searchTerm, SearchType searchType, int skip = 0, int top = 10);
}
