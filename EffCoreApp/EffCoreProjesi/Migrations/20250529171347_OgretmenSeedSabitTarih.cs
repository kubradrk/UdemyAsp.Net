using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EffCoreProjesi.Migrations
{
    /// <inheritdoc />
    public partial class OgretmenSeedSabitTarih : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ogretmenler",
                keyColumn: "OgretmenId",
                keyValue: 1,
                column: "BaslamaTarihi",
                value: new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Ogretmenler",
                keyColumn: "OgretmenId",
                keyValue: 2,
                column: "BaslamaTarihi",
                value: new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Ogretmenler",
                keyColumn: "OgretmenId",
                keyValue: 3,
                column: "BaslamaTarihi",
                value: new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Ogretmenler",
                keyColumn: "OgretmenId",
                keyValue: 4,
                column: "BaslamaTarihi",
                value: new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Ogretmenler",
                keyColumn: "OgretmenId",
                keyValue: 5,
                column: "BaslamaTarihi",
                value: new DateTime(2023, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Ogretmenler",
                keyColumn: "OgretmenId",
                keyValue: 6,
                column: "BaslamaTarihi",
                value: new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Ogretmenler",
                keyColumn: "OgretmenId",
                keyValue: 7,
                column: "BaslamaTarihi",
                value: new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Ogretmenler",
                keyColumn: "OgretmenId",
                keyValue: 8,
                column: "BaslamaTarihi",
                value: new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ogretmenler",
                keyColumn: "OgretmenId",
                keyValue: 1,
                column: "BaslamaTarihi",
                value: new DateTime(2025, 5, 29, 20, 11, 40, 138, DateTimeKind.Local).AddTicks(2451));

            migrationBuilder.UpdateData(
                table: "Ogretmenler",
                keyColumn: "OgretmenId",
                keyValue: 2,
                column: "BaslamaTarihi",
                value: new DateTime(2025, 4, 29, 20, 11, 40, 140, DateTimeKind.Local).AddTicks(523));

            migrationBuilder.UpdateData(
                table: "Ogretmenler",
                keyColumn: "OgretmenId",
                keyValue: 3,
                column: "BaslamaTarihi",
                value: new DateTime(2025, 3, 30, 20, 11, 40, 140, DateTimeKind.Local).AddTicks(581));

            migrationBuilder.UpdateData(
                table: "Ogretmenler",
                keyColumn: "OgretmenId",
                keyValue: 4,
                column: "BaslamaTarihi",
                value: new DateTime(2025, 2, 28, 20, 11, 40, 140, DateTimeKind.Local).AddTicks(585));

            migrationBuilder.UpdateData(
                table: "Ogretmenler",
                keyColumn: "OgretmenId",
                keyValue: 5,
                column: "BaslamaTarihi",
                value: new DateTime(2025, 1, 29, 20, 11, 40, 140, DateTimeKind.Local).AddTicks(587));

            migrationBuilder.UpdateData(
                table: "Ogretmenler",
                keyColumn: "OgretmenId",
                keyValue: 6,
                column: "BaslamaTarihi",
                value: new DateTime(2025, 5, 19, 20, 11, 40, 140, DateTimeKind.Local).AddTicks(589));

            migrationBuilder.UpdateData(
                table: "Ogretmenler",
                keyColumn: "OgretmenId",
                keyValue: 7,
                column: "BaslamaTarihi",
                value: new DateTime(2025, 3, 15, 20, 11, 40, 140, DateTimeKind.Local).AddTicks(591));

            migrationBuilder.UpdateData(
                table: "Ogretmenler",
                keyColumn: "OgretmenId",
                keyValue: 8,
                column: "BaslamaTarihi",
                value: new DateTime(2025, 5, 14, 20, 11, 40, 140, DateTimeKind.Local).AddTicks(593));
        }
    }
}
