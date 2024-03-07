using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;
using Torc.API.Repositories.Domain.Enums;

namespace Torc.API.Repositories.Domain.DTOs;

public record BookDto
{
    public string Title { get; set; } = null!;
    public string? Publisher { get; set; }
    public string Author { get; set; } = null!;
    public CoverType CoverType { get; set; }
    public string? ISBN { get; set; }
    public string AvailableCopies { get; set; } = null!;
    [JsonConverter(typeof(StringEnumConverter))]
    public Category Category { get; set; }

}
