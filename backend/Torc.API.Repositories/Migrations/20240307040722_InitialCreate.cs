using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Torc.API.Repositories.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalCopies = table.Column<int>(type: "int", nullable: false),
                    CopiesInUse = table.Column<int>(type: "int", nullable: false),
                    CoverType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Category", "CopiesInUse", "CoverType", "FirstName", "ISBN", "LastName", "Publisher", "Title", "TotalCopies" },
                values: new object[,]
                {
                    { 1, "Fiction", 80, "Hardcover", "Jane", "1234567891", "Austen", null, "Pride and Prejudice", 100 },
                    { 2, "Fiction", 65, "Paperback", "Harper", "1234567892", "Lee", "", "To Kill a Mockingbird", 75 },
                    { 3, "Fiction", 45, "Hardcover", "J.D.", "1234567893", "Salinger", "", "The Catcher in the Rye", 50 },
                    { 4, "NonFiction", 22, "Hardcover", "F. Scott", "1234567894", "Fitzgerald", "", "The Great Gatsby", 50 },
                    { 5, "Biography", 35, "Hardcover", "Paulo", "1234567895", "Coelho", "", "The Alchemist", 50 },
                    { 6, "Mistery", 11, "Hardcover", "Markus", "1234567896", "Zusak", "", "The Book Thief", 75 },
                    { 7, "SciFi", 14, "Paperback", "C.S.", "1234567897", "Lewis", "", "The Chronicles of Narnia", 100 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
