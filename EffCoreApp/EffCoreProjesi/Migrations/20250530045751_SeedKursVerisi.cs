using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EffCoreProjesi.Migrations
{
    /// <inheritdoc />
    public partial class SeedKursVerisi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kurslar",
                columns: new[] { "KursId", "Baslik", "OgretmenId" },
                values: new object[,]
                {
                    { 1, "Yazılım Geliştirme", 1 },
                    { 2, "Veri Tabanı", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kurslar",
                keyColumn: "KursId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kurslar",
                keyColumn: "KursId",
                keyValue: 2);
        }
    }
}
