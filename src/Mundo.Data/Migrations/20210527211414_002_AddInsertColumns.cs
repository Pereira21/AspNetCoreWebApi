using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mundo.Data.Migrations
{
    public partial class _002_AddInsertColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "_Insert",
                table: "Pet",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "_Insert",
                table: "Pessoa",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_Insert",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "_Insert",
                table: "Pessoa");
        }
    }
}
