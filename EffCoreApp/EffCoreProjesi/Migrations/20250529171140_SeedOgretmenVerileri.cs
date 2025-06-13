using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EffCoreProjesi.Migrations
{
    /// <inheritdoc />
    public partial class SeedOgretmenVerileri : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ogretmenler",
                columns: new[] { "OgretmenId", "Ad", "BaslamaTarihi", "Eposta", "Soyad", "Telefon" },
                values: new object[,]
                {
                    { 1, "Ayşe", new DateTime(2025, 5, 29, 20, 11, 40, 138, DateTimeKind.Local).AddTicks(2451), "ayse.yilmaz@example.com", "Yılmaz", "0555 123 45 67" },
                    { 2, "Mehmet", new DateTime(2025, 4, 29, 20, 11, 40, 140, DateTimeKind.Local).AddTicks(523), "mehmet.kara@example.com", "Kara", "0532 456 78 90" },
                    { 3, "Elif", new DateTime(2025, 3, 30, 20, 11, 40, 140, DateTimeKind.Local).AddTicks(581), "elif.demir@example.com", "Demir", "0506 111 22 33" },
                    { 4, "Ahmet", new DateTime(2025, 2, 28, 20, 11, 40, 140, DateTimeKind.Local).AddTicks(585), "ahmet.sahin@example.com", "Şahin", "0544 333 22 11" },
                    { 5, "Zeynep", new DateTime(2025, 1, 29, 20, 11, 40, 140, DateTimeKind.Local).AddTicks(587), "zeynep.aslan@example.com", "Aslan", "0530 876 54 32" },
                    { 6, "Kemal", new DateTime(2025, 5, 19, 20, 11, 40, 140, DateTimeKind.Local).AddTicks(589), "kemal.aydin@example.com", "Aydın", "0553 345 67 89" },
                    { 7, "Fatma", new DateTime(2025, 3, 15, 20, 11, 40, 140, DateTimeKind.Local).AddTicks(591), "fatma.gunes@example.com", "Güneş", "0541 234 56 78" },
                    { 8, "Yusuf", new DateTime(2025, 5, 14, 20, 11, 40, 140, DateTimeKind.Local).AddTicks(593), "yusuf.kilic@example.com", "Kılıç", "0539 999 88 77" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ogretmenler",
                keyColumn: "OgretmenId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ogretmenler",
                keyColumn: "OgretmenId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ogretmenler",
                keyColumn: "OgretmenId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ogretmenler",
                keyColumn: "OgretmenId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ogretmenler",
                keyColumn: "OgretmenId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ogretmenler",
                keyColumn: "OgretmenId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ogretmenler",
                keyColumn: "OgretmenId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ogretmenler",
                keyColumn: "OgretmenId",
                keyValue: 8);
        }
    }
}
