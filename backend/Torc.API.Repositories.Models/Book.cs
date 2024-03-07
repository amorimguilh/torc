using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Torc.API.Repositories.Domain.Enums;

namespace Torc.API.Repositories.Models;

public record Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(100)]
    public string Title { get; set; } = null!;
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;
    [MaxLength(50)]
    public string LastName { get; set; } = null!;
    public int TotalCopies { get; set; }
    public int CopiesInUse { get; set; }
    public string CoverType { get; set; } = null!;
    [MaxLength(50)]
    public string? ISBN { get; set; }
    public string Category { get; set; } = null!;
    public string? Publisher { get; set; } = null!;
}