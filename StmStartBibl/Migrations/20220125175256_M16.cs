using Microsoft.EntityFrameworkCore.Migrations;

namespace StmStartBibl.Migrations
{
    public partial class M16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Reception",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reception_ClientID",
                table: "Reception",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reception_Client_ClientID",
                table: "Reception",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reception_Client_ClientID",
                table: "Reception");

            migrationBuilder.DropIndex(
                name: "IX_Reception_ClientID",
                table: "Reception");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Reception");
        }
    }
}
