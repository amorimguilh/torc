using Torc.API.Repositories.Domain.DTOs;
using Torc.API.Repositories.Models;

namespace Torc.API.Mappers.Interfaces;

public interface IBookMapper
{
    IEnumerable<BookDto> ToDto(IEnumerable<Book> bookModels);
}
