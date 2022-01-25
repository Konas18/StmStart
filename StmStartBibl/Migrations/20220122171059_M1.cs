using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace StmStartBibl.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Lastname = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    Date_of_birth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Medical_history = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Clinic",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Clinic_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinic", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Delivery_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Amount_spent = table.Column<decimal>(type: "numeric", nullable: false),
                    Product_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Post_name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Access_level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date_of_admission = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Reception_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ClientID = table.Column<int>(type: "integer", nullable: true),
                    ClinicID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Schedule_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedule_Clinic_ClinicID",
                        column: x => x.ClinicID,
                        principalTable: "Clinic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Material_name = table.Column<string>(type: "text", nullable: true),
                    Date_of_purchase = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Expiration_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    DeliveriesID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Material_Deliveries_DeliveriesID",
                        column: x => x.DeliveriesID,
                        principalTable: "Deliveries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Lastname = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    Date_of_birth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Experience = table.Column<int>(type: "integer", nullable: false),
                    ClinicID = table.Column<int>(type: "integer", nullable: true),
                    PostID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Personal_Clinic_ClinicID",
                        column: x => x.ClinicID,
                        principalTable: "Clinic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personal_Post_PostID",
                        column: x => x.PostID,
                        principalTable: "Post",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Services_name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Required_amount_of_material = table.Column<int>(type: "integer", nullable: false),
                    MaterialID = table.Column<int>(type: "integer", nullable: true),
                    ClinicID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Services_Clinic_ClinicID",
                        column: x => x.ClinicID,
                        principalTable: "Clinic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_Material_MaterialID",
                        column: x => x.MaterialID,
                        principalTable: "Material",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Сontract",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number_contract = table.Column<string>(type: "text", nullable: true),
                    Date_contract = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ClientID = table.Column<int>(type: "integer", nullable: true),
                    PersonalID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сontract", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Сontract_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Сontract_Personal_PersonalID",
                        column: x => x.PersonalID,
                        principalTable: "Personal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reception",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Complaints = table.Column<string>(type: "text", nullable: true),
                    External_inspection_data = table.Column<string>(type: "text", nullable: true),
                    Treatment_plan = table.Column<string>(type: "text", nullable: true),
                    PersonalID = table.Column<int>(type: "integer", nullable: true),
                    ScheduleID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reception", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reception_Personal_PersonalID",
                        column: x => x.PersonalID,
                        principalTable: "Personal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reception_Schedule_ScheduleID",
                        column: x => x.ScheduleID,
                        principalTable: "Schedule",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tooth_History",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Reception_history = table.Column<string>(type: "text", nullable: true),
                    ClientID = table.Column<int>(type: "integer", nullable: true),
                    ServicesID = table.Column<int>(type: "integer", nullable: true),
                    ReceptionID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tooth_History", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tooth_History_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tooth_History_Reception_ReceptionID",
                        column: x => x.ReceptionID,
                        principalTable: "Reception",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tooth_History_Services_ServicesID",
                        column: x => x.ServicesID,
                        principalTable: "Services",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Сontract_ClientID",
                table: "Сontract",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Сontract_PersonalID",
                table: "Сontract",
                column: "PersonalID");

            migrationBuilder.CreateIndex(
                name: "IX_Material_DeliveriesID",
                table: "Material",
                column: "DeliveriesID");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_ClinicID",
                table: "Personal",
                column: "ClinicID");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_PostID",
                table: "Personal",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_Reception_PersonalID",
                table: "Reception",
                column: "PersonalID");

            migrationBuilder.CreateIndex(
                name: "IX_Reception_ScheduleID",
                table: "Reception",
                column: "ScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_ClientID",
                table: "Schedule",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_ClinicID",
                table: "Schedule",
                column: "ClinicID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ClinicID",
                table: "Services",
                column: "ClinicID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_MaterialID",
                table: "Services",
                column: "MaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_Tooth_History_ClientID",
                table: "Tooth_History",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Tooth_History_ReceptionID",
                table: "Tooth_History",
                column: "ReceptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Tooth_History_ServicesID",
                table: "Tooth_History",
                column: "ServicesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Сontract");

            migrationBuilder.DropTable(
                name: "Tooth_History");

            migrationBuilder.DropTable(
                name: "Reception");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Personal");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Clinic");

            migrationBuilder.DropTable(
                name: "Deliveries");
        }
    }
}
