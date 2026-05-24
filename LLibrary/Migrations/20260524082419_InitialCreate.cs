using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Readers",
                columns: table => new
                {
                    ReaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClassNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readers", x => x.ReaderId);
                });

            migrationBuilder.CreateTable(
                name: "StorageLocations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Room = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Shelf = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageLocations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookMovements",
                columns: table => new
                {
                    MovementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    ReaderId = table.Column<int>(type: "int", nullable: true),
                    FromLocationId = table.Column<int>(type: "int", nullable: true),
                    ToLocationId = table.Column<int>(type: "int", nullable: true),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReturned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookMovements", x => x.MovementId);
                    table.ForeignKey(
                        name: "FK_BookMovements_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookMovements_Readers_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Readers",
                        principalColumn: "ReaderId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BookMovements_StorageLocations_FromLocationId",
                        column: x => x.FromLocationId,
                        principalTable: "StorageLocations",
                        principalColumn: "LocationId");
                    table.ForeignKey(
                        name: "FK_BookMovements_StorageLocations_ToLocationId",
                        column: x => x.ToLocationId,
                        principalTable: "StorageLocations",
                        principalColumn: "LocationId");
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1828, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Лев", "Толстой" },
                    { 2, new DateTime(1821, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Фёдор", "Достоевский" }
                });

            migrationBuilder.InsertData(
                table: "Readers",
                columns: new[] { "ReaderId", "ClassNumber", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "10-А", "Иван", "Иванов" },
                    { 2, "9-Б", "Петр", "Петров" }
                });

            migrationBuilder.InsertData(
                table: "StorageLocations",
                columns: new[] { "LocationId", "Room", "Shelf" },
                values: new object[,]
                {
                    { 1, "Читальный зал", "Стеллаж 1" },
                    { 2, "Архив", "Стеллаж 10" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "ISBN", "Title" },
                values: new object[,]
                {
                    { 1, 1, "978-5-17-01", "Война и мир" },
                    { 2, 1, "978-5-17-02", "Анна Каренина" },
                    { 3, 2, "978-5-17-03", "Преступление и наказание" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookMovements_BookId",
                table: "BookMovements",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookMovements_FromLocationId",
                table: "BookMovements",
                column: "FromLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_BookMovements_ReaderId",
                table: "BookMovements",
                column: "ReaderId");

            migrationBuilder.CreateIndex(
                name: "IX_BookMovements_ToLocationId",
                table: "BookMovements",
                column: "ToLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ISBN",
                table: "Books",
                column: "ISBN",
                unique: true,
                filter: "[ISBN] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookMovements");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Readers");

            migrationBuilder.DropTable(
                name: "StorageLocations");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
