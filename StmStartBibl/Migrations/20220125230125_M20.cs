using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StmStartBibl.Migrations
{
    public partial class M20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
