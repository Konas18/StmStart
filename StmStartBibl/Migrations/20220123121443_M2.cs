using Microsoft.EntityFrameworkCore.Migrations;

namespace StmStartBibl.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Patronymic",
                table: "Client",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Client",
                newName: "Phone");

            migrationBuilder.AddColumn<string>(
                name: "Addres",
                table: "Client",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pasport",
                table: "Client",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Addres",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Pasport",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Client",
                newName: "Patronymic");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Client",
                newName: "Address");
        }
    }
}
