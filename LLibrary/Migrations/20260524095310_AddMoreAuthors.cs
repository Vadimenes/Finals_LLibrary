using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreAuthors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 3, new DateTime(1889, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Анна", "Ахматова" },
                    { 4, new DateTime(1831, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Николай", "Лесков" },
                    { 5, new DateTime(1809, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Николай", "Гоголь" },
                    { 6, new DateTime(1799, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Александр", "Пушкин" },
                    { 7, new DateTime(1860, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Антон", "Чехов" },
                    { 8, new DateTime(1818, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Иван", "Тургенев" },
                    { 9, new DateTime(1814, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Михаил", "Лермонтов" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 9);
        }
    }
}
