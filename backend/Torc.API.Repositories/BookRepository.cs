using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Torc.API.Repositories.Domain.Enums;
using Torc.API.Repositories.Interfaces;
using Torc.API.Repositories.Models;

namespace Torc.API.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookDbContext _context;
    private readonly ILogger<BookRepository> _logger;

    public BookRepository(BookDbContext context, ILogger<BookRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<Book>> SearchBooksAsync(string searchTerm, SearchType searchType, int skip = 0, int take = 10)
    {
        _logger.LogInformation("retrieving books");
        IQueryable<Book>? query = null;

        switch (searchType)
        {
            case SearchType.Author:
                query = BuildSearchByAuthorQuery(searchTerm);
                break;
            case SearchType.ISBN:
                query = _context.Books.Where(book => book.ISBN != null && book.ISBN.ToLower().Equals(searchTerm.ToLower())).AsNoTracking();
                break;
        }

        if (query == null) return new List<Book>();
        return await query.Skip(skip).Take(take).ToListAsync().ConfigureAwait(false);

    }

    private IQueryable<Book> BuildSearchByAuthorQuery(string searchTerm)
    {
        return _context.Books
            .Where(book => EF.Functions.Like(book.FirstName.ToLower() + " " + book.LastName.ToLower(), "%" + searchTerm.ToLower() + "%")).AsNoTracking();
            
    }
}