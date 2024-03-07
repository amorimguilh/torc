using Microsoft.EntityFrameworkCore;
using Torc.API.Repositories.Domain.Enums;
using Torc.API.Repositories.Models;

namespace Torc.API.Repositories;

public class BookDbContext : DbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options)
            : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                Title = "Pride and Prejudice",
                FirstName = "Jane",
                LastName = "Austen",
                TotalCopies = 100,
                CopiesInUse = 80,
                ISBN = "1234567891",
                Category = Category.Fiction,
                CoverType = CoverType.Hardcover
            },
            new Book
            {
                Id = 2,
                Title = "To Kill a Mockingbird",
                FirstName = "Harper",
                LastName = "Lee",
                TotalCopies = 75,
                CopiesInUse = 65,
                ISBN = "1234567892",
                Category = Category.Fiction,
                CoverType = CoverType.Paperback,
                Publisher = ""
            },
            new Book
            {
                Id = 3,
                Title = "The Catcher in the Rye",
                FirstName = "J.D.",
                LastName = "Salinger",
                TotalCopies = 50,
                CopiesInUse = 45,
                ISBN = "1234567893",
                Category = Category.Fiction,
                CoverType = CoverType.Hardcover,
                Publisher = ""
            },
            new Book
            {
                Id = 4,
                Title = "The Great Gatsby",
                FirstName = "F. Scott",
                LastName = "Fitzgerald",
                TotalCopies = 50,
                CopiesInUse = 22,
                ISBN = "1234567894",
                Category = Category.NonFiction,
                CoverType = CoverType.Hardcover,
                Publisher = ""
            },
            new Book
            {
                Id = 5,
                Title = "The Alchemist",
                FirstName = "Paulo",
                LastName = "Coelho",
                TotalCopies = 50,
                CopiesInUse = 35,
                ISBN = "1234567895",
                Category = Category.Biography,
                CoverType = CoverType.Hardcover,
                Publisher = ""
            },
            new Book
            {
                Id = 6,
                Title = "The Book Thief",
                FirstName = "Markus",
                LastName = "Zusak",
                TotalCopies = 75,
                CopiesInUse = 11,
                ISBN = "1234567896",
                Category = Category.Mistery,
                CoverType = CoverType.Hardcover,
                Publisher = ""
            },
            new Book
            {
                Id = 7,
                Title = "The Chronicles of Narnia",
                FirstName = "C.S.",
                LastName = "Lewis",
                TotalCopies = 100,
                CopiesInUse = 14,
                ISBN = "1234567897",
                Category = Category.SciFi,
                CoverType = CoverType.Paperback,
                Publisher = ""
            });
    }
}

