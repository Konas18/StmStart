﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StmStartBibl;

namespace StmStartBibl.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220122171059_M1")]
    partial class M1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("StmStartBibl.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date_of_birth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Lastname")
                        .HasColumnType("text");

                    b.Property<string>("Medical_history")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("StmStartBibl.Clinic", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Clinic_name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Clinic");
                });

            modelBuilder.Entity("StmStartBibl.Deliveries", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("Amount_spent")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("Delivery_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Product_name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("StmStartBibl.Material", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Date_of_purchase")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("DeliveriesID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Expiration_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Material_name")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("DeliveriesID");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("StmStartBibl.Personal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ClinicID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date_of_birth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Experience")
                        .HasColumnType("integer");

                    b.Property<string>("Lastname")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<int?>("PostID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("ClinicID");

                    b.HasIndex("PostID");

                    b.ToTable("Personal");
                });

            modelBuilder.Entity("StmStartBibl.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Access_level")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Post_name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("StmStartBibl.Reception", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Complaints")
                        .HasColumnType("text");

                    b.Property<string>("External_inspection_data")
                        .HasColumnType("text");

                    b.Property<int?>("PersonalID")
                        .HasColumnType("integer");

                    b.Property<int?>("ScheduleID")
                        .HasColumnType("integer");

                    b.Property<string>("Treatment_plan")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("PersonalID");

                    b.HasIndex("ScheduleID");

                    b.ToTable("Reception");
                });

            modelBuilder.Entity("StmStartBibl.Schedule", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ClientID")
                        .HasColumnType("integer");

                    b.Property<int?>("ClinicID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date_of_admission")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Reception_time")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("ClinicID");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("StmStartBibl.Services", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ClinicID")
                        .HasColumnType("integer");

                    b.Property<int?>("MaterialID")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Required_amount_of_material")
                        .HasColumnType("integer");

                    b.Property<string>("Services_name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("ClinicID");

                    b.HasIndex("MaterialID");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("StmStartBibl.Tooth_History", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ClientID")
                        .HasColumnType("integer");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<int?>("ReceptionID")
                        .HasColumnType("integer");

                    b.Property<string>("Reception_history")
                        .HasColumnType("text");

                    b.Property<int?>("ServicesID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("ReceptionID");

                    b.HasIndex("ServicesID");

                    b.ToTable("Tooth_History");
                });

            modelBuilder.Entity("StmStartBibl.Сontract", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ClientID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date_contract")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Number_contract")
                        .HasColumnType("text");

                    b.Property<int?>("PersonalID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("PersonalID");

                    b.ToTable("Сontract");
                });

            modelBuilder.Entity("StmStartBibl.Material", b =>
                {
                    b.HasOne("StmStartBibl.Deliveries", "Deliveries")
                        .WithMany()
                        .HasForeignKey("DeliveriesID");

                    b.Navigation("Deliveries");
                });

            modelBuilder.Entity("StmStartBibl.Personal", b =>
                {
                    b.HasOne("StmStartBibl.Clinic", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicID");

                    b.HasOne("StmStartBibl.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostID");

                    b.Navigation("Clinic");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("StmStartBibl.Reception", b =>
                {
                    b.HasOne("StmStartBibl.Personal", "Personal")
                        .WithMany()
                        .HasForeignKey("PersonalID");

                    b.HasOne("StmStartBibl.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleID");

                    b.Navigation("Personal");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("StmStartBibl.Schedule", b =>
                {
                    b.HasOne("StmStartBibl.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID");

                    b.HasOne("StmStartBibl.Clinic", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicID");

                    b.Navigation("Client");

                    b.Navigation("Clinic");
                });

            modelBuilder.Entity("StmStartBibl.Services", b =>
                {
                    b.HasOne("StmStartBibl.Clinic", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicID");

                    b.HasOne("StmStartBibl.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialID");

                    b.Navigation("Clinic");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("StmStartBibl.Tooth_History", b =>
                {
                    b.HasOne("StmStartBibl.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID");

                    b.HasOne("StmStartBibl.Reception", "Reception")
                        .WithMany()
                        .HasForeignKey("ReceptionID");

                    b.HasOne("StmStartBibl.Services", "Services")
                        .WithMany()
                        .HasForeignKey("ServicesID");

                    b.Navigation("Client");

                    b.Navigation("Reception");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("StmStartBibl.Сontract", b =>
                {
                    b.HasOne("StmStartBibl.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID");

                    b.HasOne("StmStartBibl.Personal", "Personal")
                        .WithMany()
                        .HasForeignKey("PersonalID");

                    b.Navigation("Client");

                    b.Navigation("Personal");
                });
#pragma warning restore 612, 618
        }
    }
}
