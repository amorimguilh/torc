using Torc.API.Mappers.Interfaces;
using Torc.API.Repositories.Domain.DTOs;
using Torc.API.Repositories.Models;

namespace Torc.API.Mappers;

public class BookMapper : IBookMapper
{
    private BookDto ToDto(Book book)
    {
        return new BookDto
        {
            Author = $"{book.FirstName} {book.LastName}",
            AvailableCopies = $"{book.CopiesInUse}/{book.TotalCopies}",
            Category = book.Category,
            ISBN = book?.ISBN,
            Publisher = book.Publisher,
            Title = book.Title,
            CoverType = book.CoverType
        };
    }

    public IEnumerable<BookDto> ToDto(IEnumerable<Book> bookModels)
    {
        List<BookDto> dtos = new();
        foreach (var book in bookModels)
        {
            dtos.Add(ToDto(book));
        }

        return dtos;
    }
}
