using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EffCoreProjesi.Migrations
{
    /// <inheritdoc />
    public partial class SeedKursKayit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "KursKayitlari",
                columns: new[] { "KayitId", "KayitTarihi", "KursId", "OgrenciId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "KursKayitlari",
                keyColumn: "KayitId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "KursKayitlari",
                keyColumn: "KayitId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "KursKayitlari",
                keyColumn: "KayitId",
                keyValue: 3);
        }
    }
}
