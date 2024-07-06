using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPICore.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "BirthDate", "Email", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 29, 11, 0, 20, 612, DateTimeKind.Local).AddTicks(433), "nick@email.com", "Nick" },
                    { 2, new DateTime(2024, 6, 29, 11, 0, 20, 612, DateTimeKind.Local).AddTicks(525), "bob@email.com", "Bob" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
