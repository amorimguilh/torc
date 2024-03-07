using Microsoft.AspNetCore.Mvc;
using Torc.API.Repositories.Domain.Enums;
using Torc.API.Services.Interfaces;

namespace Torc.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BookSearchController : ControllerBase
{
    private readonly IBookSearchService _bookSearchService;
    private readonly ILogger<BookSearchController> _logger;

    public BookSearchController(IBookSearchService bookSearchService, ILogger<BookSearchController> logger)
    {
        _bookSearchService = bookSearchService;
        _logger = logger;
    }

    [HttpGet(Name = "Search")]
    public async Task<IActionResult> Search(string searchTem, SearchType searchType, int skip=0, int top = 10)
    {
        _logger.LogInformation("Seaching books");
       var books = await _bookSearchService.SearchAsync(searchTem, searchType, skip, top);
       return Ok(books);
    }
}