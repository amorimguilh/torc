using Torc.API.Repositories.Domain.Enums;
using Torc.API.Repositories.Models;

namespace Torc.API.Repositories.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Book>> SearchBooksAsync(string searchTerm, SearchType searchType, int skip = 0, int take = 10);
}
