// <auto-generated />
using System;
using EmployeeApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeApi.Migrations
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20220713070954_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeApi.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ops"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Fin"
                        });
                });

            modelBuilder.Entity("EmployeeApi.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("Username");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            Age = 21,
                            DepartmentId = 1,
                            Name = "Suman"
                        },
                        new
                        {
                            Id = 102,
                            Age = 20,
                            DepartmentId = 1,
                            Name = "Zenith"
                        },
                        new
                        {
                            Id = 103,
                            Age = 22,
                            DepartmentId = 2,
                            Name = "Preeti"
                        });
                });

            modelBuilder.Entity("EmployeeApi.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("HashKey")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Password")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EmployeeApi.Models.Employee", b =>
                {
                    b.HasOne("EmployeeApi.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeApi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Username");

                    b.Navigation("Department");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EmployeeApi.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
