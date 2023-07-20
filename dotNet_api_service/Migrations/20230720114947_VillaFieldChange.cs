using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotNet_api_service.Migrations
{
    /// <inheritdoc />
    public partial class VillaFieldChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 20, 13, 49, 47, 77, DateTimeKind.Local).AddTicks(5246));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 20, 13, 49, 47, 77, DateTimeKind.Local).AddTicks(5292));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 7, 20, 13, 49, 47, 77, DateTimeKind.Local).AddTicks(5295));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 7, 20, 13, 49, 47, 77, DateTimeKind.Local).AddTicks(5297));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 7, 20, 13, 49, 47, 77, DateTimeKind.Local).AddTicks(5301));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 7, 20, 13, 49, 47, 77, DateTimeKind.Local).AddTicks(5304));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 7, 20, 11, 28, 20, 185, DateTimeKind.Local).AddTicks(1925));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 7, 20, 11, 28, 20, 185, DateTimeKind.Local).AddTicks(1980));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 7, 20, 11, 28, 20, 185, DateTimeKind.Local).AddTicks(1983));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 7, 20, 11, 28, 20, 185, DateTimeKind.Local).AddTicks(1986));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2023, 7, 20, 11, 28, 20, 185, DateTimeKind.Local).AddTicks(1989));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2023, 7, 20, 11, 28, 20, 185, DateTimeKind.Local).AddTicks(1992));
        }
    }
}
