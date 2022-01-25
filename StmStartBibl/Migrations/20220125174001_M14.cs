using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StmStartBibl.Migrations
{
    public partial class M14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeService",
                table: "Tooth_History");

            migrationBuilder.DropColumn(
                name: "Sum",
                table: "Tooth_History");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeService",
                table: "Reception",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Sum",
                table: "Reception",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeService",
                table: "Reception");

            migrationBuilder.DropColumn(
                name: "Sum",
                table: "Reception");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeService",
                table: "Tooth_History",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Sum",
                table: "Tooth_History",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
