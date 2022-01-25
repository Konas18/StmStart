using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StmStartBibl.Migrations
{
    public partial class M10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reception_history",
                table: "Tooth_History");

            migrationBuilder.DropColumn(
                name: "ToothNumber",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Tooth_History",
                newName: "ToothNumber");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeService",
                table: "Tooth_History",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeService",
                table: "Tooth_History");

            migrationBuilder.RenameColumn(
                name: "ToothNumber",
                table: "Tooth_History",
                newName: "Number");

            migrationBuilder.AddColumn<string>(
                name: "Reception_history",
                table: "Tooth_History",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToothNumber",
                table: "Services",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
