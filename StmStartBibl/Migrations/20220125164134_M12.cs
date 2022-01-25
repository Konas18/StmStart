using Microsoft.EntityFrameworkCore.Migrations;

namespace StmStartBibl.Migrations
{
    public partial class M12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Tooth_History",
                newName: "Sum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sum",
                table: "Tooth_History",
                newName: "Price");
        }
    }
}
