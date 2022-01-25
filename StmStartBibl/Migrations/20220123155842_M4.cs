using Microsoft.EntityFrameworkCore.Migrations;

namespace StmStartBibl.Migrations
{
    public partial class M4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Patronymic",
                table: "Personal",
                newName: "Surname");

            migrationBuilder.AddColumn<string>(
                name: "Pasport",
                table: "Personal",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Personal",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostName",
                table: "Personal",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pasport",
                table: "Personal");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Personal");

            migrationBuilder.DropColumn(
                name: "PostName",
                table: "Personal");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Personal",
                newName: "Patronymic");
        }
    }
}
