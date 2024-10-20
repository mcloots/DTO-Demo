using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Book.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsInStock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageNumber = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pages_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "IsInStock", "Title" },
                values: new object[,]
                {
                    { new Guid("a56c6700-c556-4345-ae64-f56babbfd5de"), "Author A", true, "Book One" },
                    { new Guid("f0816a79-543b-42a8-b6e2-fa24cb228aba"), "Author B", false, "Book Two" }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "BookId", "Content", "PageNumber" },
                values: new object[,]
                {
                    { new Guid("0ef336f4-bf0a-40ba-bb9e-70b2298aadd8"), new Guid("f0816a79-543b-42a8-b6e2-fa24cb228aba"), "Content of page 1 in Book Two", 1 },
                    { new Guid("6dfdf426-5529-49d2-be1d-9e3b9fdc3485"), new Guid("a56c6700-c556-4345-ae64-f56babbfd5de"), "Content of page 2 in Book One", 2 },
                    { new Guid("8785b229-efec-4360-8572-1529cc210e9e"), new Guid("a56c6700-c556-4345-ae64-f56babbfd5de"), "Content of page 1 in Book One", 1 },
                    { new Guid("8ee36fb7-92e3-46d9-af52-8f5a4781857b"), new Guid("f0816a79-543b-42a8-b6e2-fa24cb228aba"), "Content of page 2 in Book Two", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pages_BookId",
                table: "Pages",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
