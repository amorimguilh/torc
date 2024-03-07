﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Torc.API.Repositories;

#nullable disable

namespace Torc.API.Repositories.Migrations
{
    [DbContext(typeof(BookDbContext))]
    [Migration("20240307040722_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Torc.API.Repositories.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CopiesInUse")
                        .HasColumnType("int");

                    b.Property<string>("CoverType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ISBN")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Publisher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TotalCopies")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Fiction",
                            CopiesInUse = 80,
                            CoverType = "Hardcover",
                            FirstName = "Jane",
                            ISBN = "1234567891",
                            LastName = "Austen",
                            Title = "Pride and Prejudice",
                            TotalCopies = 100
                        },
                        new
                        {
                            Id = 2,
                            Category = "Fiction",
                            CopiesInUse = 65,
                            CoverType = "Paperback",
                            FirstName = "Harper",
                            ISBN = "1234567892",
                            LastName = "Lee",
                            Publisher = "",
                            Title = "To Kill a Mockingbird",
                            TotalCopies = 75
                        },
                        new
                        {
                            Id = 3,
                            Category = "Fiction",
                            CopiesInUse = 45,
                            CoverType = "Hardcover",
                            FirstName = "J.D.",
                            ISBN = "1234567893",
                            LastName = "Salinger",
                            Publisher = "",
                            Title = "The Catcher in the Rye",
                            TotalCopies = 50
                        },
                        new
                        {
                            Id = 4,
                            Category = "NonFiction",
                            CopiesInUse = 22,
                            CoverType = "Hardcover",
                            FirstName = "F. Scott",
                            ISBN = "1234567894",
                            LastName = "Fitzgerald",
                            Publisher = "",
                            Title = "The Great Gatsby",
                            TotalCopies = 50
                        },
                        new
                        {
                            Id = 5,
                            Category = "Biography",
                            CopiesInUse = 35,
                            CoverType = "Hardcover",
                            FirstName = "Paulo",
                            ISBN = "1234567895",
                            LastName = "Coelho",
                            Publisher = "",
                            Title = "The Alchemist",
                            TotalCopies = 50
                        },
                        new
                        {
                            Id = 6,
                            Category = "Mistery",
                            CopiesInUse = 11,
                            CoverType = "Hardcover",
                            FirstName = "Markus",
                            ISBN = "1234567896",
                            LastName = "Zusak",
                            Publisher = "",
                            Title = "The Book Thief",
                            TotalCopies = 75
                        },
                        new
                        {
                            Id = 7,
                            Category = "SciFi",
                            CopiesInUse = 14,
                            CoverType = "Paperback",
                            FirstName = "C.S.",
                            ISBN = "1234567897",
                            LastName = "Lewis",
                            Publisher = "",
                            Title = "The Chronicles of Narnia",
                            TotalCopies = 100
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
