﻿// <auto-generated />
using System;
using AttendanceManagementSystem.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AttendanceManagementSystem.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AttendanceManagementSystem.models.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Day")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Finish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("NoOfHours")
                        .HasColumnType("float");

                    b.Property<string>("Start")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("traineeIdId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("traineeIdId");

                    b.ToTable("attendances");
                });

            modelBuilder.Entity("AttendanceManagementSystem.models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("AttendanceManagementSystem.models.Manger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Eamil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("mangers");
                });

            modelBuilder.Entity("AttendanceManagementSystem.models.Trainee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("departmentIdId")
                        .HasColumnType("int");

                    b.Property<int?>("managerIdId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("departmentIdId");

                    b.HasIndex("managerIdId");

                    b.ToTable("trainees");
                });

            modelBuilder.Entity("AttendanceManagementSystem.models.Attendance", b =>
                {
                    b.HasOne("AttendanceManagementSystem.models.Trainee", "traineeId")
                        .WithMany()
                        .HasForeignKey("traineeIdId");

                    b.Navigation("traineeId");
                });

            modelBuilder.Entity("AttendanceManagementSystem.models.Trainee", b =>
                {
                    b.HasOne("AttendanceManagementSystem.models.Department", "departmentId")
                        .WithMany()
                        .HasForeignKey("departmentIdId");

                    b.HasOne("AttendanceManagementSystem.models.Manger", "managerId")
                        .WithMany()
                        .HasForeignKey("managerIdId");

                    b.Navigation("departmentId");

                    b.Navigation("managerId");
                });
#pragma warning restore 612, 618
        }
    }
}
