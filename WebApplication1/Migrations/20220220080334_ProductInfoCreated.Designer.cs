﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220220080334_ProductInfoCreated")]
    partial class ProductInfoCreated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.BloodGroupInformations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.ToTable("BloodGroupInformations");

                    b.HasData(
                        new { Id = 1, CreatedBy = 1, CreatedDate = new DateTime(2022, 2, 20, 12, 3, 34, 220, DateTimeKind.Local), IsActive = true, Name = "A+" }
                    );
                });

            modelBuilder.Entity("WebApplication1.Models.DepartmentInformations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.ToTable("DepartmentInformations");

                    b.HasData(
                        new { Id = 1, CreatedBy = 1, CreatedDate = new DateTime(2022, 2, 20, 12, 3, 34, 212, DateTimeKind.Local), IsActive = true, Name = "Accounting" }
                    );
                });

            modelBuilder.Entity("WebApplication1.Models.DesignationInformations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.ToTable("DesignationInformations");

                    b.HasData(
                        new { Id = 1, CreatedBy = 1, CreatedDate = new DateTime(2022, 2, 20, 12, 3, 34, 216, DateTimeKind.Local), IsActive = true, Name = "Driver" }
                    );
                });

            modelBuilder.Entity("WebApplication1.Models.EmployeeInformations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(500);

                    b.Property<int>("Age");

                    b.Property<int>("BloodGroupId");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("DateofBirth");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<int>("DesignationId");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("EmergencyContactNumber");

                    b.Property<int>("GenderId");

                    b.Property<DateTime>("HireDate");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsActive");

                    b.Property<string>("MobileNumber");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("BloodGroupId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DesignationId");

                    b.ToTable("EmployeeInformations");

                    b.HasData(
                        new { Id = 1, Address = "jos 10 faren street s6, no 1099", Age = 25, BloodGroupId = 1, CreatedBy = 1, CreatedDate = new DateTime(2022, 2, 20, 12, 3, 34, 222, DateTimeKind.Local), DateofBirth = new DateTime(2022, 2, 20, 12, 3, 34, 222, DateTimeKind.Local), DepartmentId = 1, Description = "this is test Employee From Seed", DesignationId = 1, EmailAddress = "test@gmail.com", EmergencyContactNumber = "64648464412", GenderId = 1, HireDate = new DateTime(2022, 2, 20, 12, 3, 34, 223, DateTimeKind.Local), ImageUrl = "jas.jpg", IsActive = true, MobileNumber = "1231464612", Name = "Test Name" }
                    );
                });

            modelBuilder.Entity("WebApplication1.Models.GenderInformations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenderName");

                    b.HasKey("Id");

                    b.ToTable("Genders");

                    b.HasData(
                        new { Id = 1, GenderName = "Male" },
                        new { Id = 2, GenderName = "Female" }
                    );
                });

            modelBuilder.Entity("WebApplication1.Models.ProductInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("UnitId");

                    b.HasKey("Id");

                    b.ToTable("ProductInfos");

                    b.HasData(
                        new { Id = 1, CreatedBy = 1, CreatedDate = new DateTime(2022, 2, 20, 12, 3, 34, 220, DateTimeKind.Local), Description = "this is from seed,for test purpose", IsActive = true, Name = "Letter", UnitId = 1 }
                    );
                });

            modelBuilder.Entity("WebApplication1.Models.TrackUpdateInformations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AfterUpdate");

                    b.Property<string>("BeforeUpdate");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("UpdateInfo");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.ToTable("TrackUpdateInformations");

                    b.HasData(
                        new { Id = 1, AfterUpdate = "Driver Name", BeforeUpdate = "Driver", CreatedBy = 1, CreatedDate = new DateTime(2022, 2, 20, 12, 3, 34, 224, DateTimeKind.Local), IsActive = true, UpdateInfo = "Driver Update to Driver Name" }
                    );
                });

            modelBuilder.Entity("WebApplication1.Models.UnitInformations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.ToTable("UnitInformations");

                    b.HasData(
                        new { Id = 1, CreatedBy = 1, CreatedDate = new DateTime(2022, 2, 20, 12, 3, 34, 218, DateTimeKind.Local), IsActive = true, Name = "Letter" }
                    );
                });

            modelBuilder.Entity("WebApplication1.Models.UserInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("GenderId");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsActive");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("UserInformations");

                    b.HasData(
                        new { Id = 1, CreatedDate = new DateTime(2022, 2, 20, 12, 3, 34, 212, DateTimeKind.Local), FullName = "Admin", GenderId = 1, IsActive = true, UserName = "admin@gmail.com", UserPassword = "12345678" }
                    );
                });

            modelBuilder.Entity("WebApplication1.Models.BloodGroupInformations", b =>
                {
                    b.HasOne("WebApplication1.Models.UserInformation", "UserInformation")
                        .WithMany("BloodGroupInformations")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication1.Models.DepartmentInformations", b =>
                {
                    b.HasOne("WebApplication1.Models.UserInformation", "UserInformation")
                        .WithMany("DepartmentInformations")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication1.Models.DesignationInformations", b =>
                {
                    b.HasOne("WebApplication1.Models.UserInformation", "UserInformation")
                        .WithMany("DesignationInformations")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication1.Models.EmployeeInformations", b =>
                {
                    b.HasOne("WebApplication1.Models.BloodGroupInformations", "BloodGroupInformations")
                        .WithMany("EmployeeInformations")
                        .HasForeignKey("BloodGroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication1.Models.UserInformation", "UserInformation")
                        .WithMany("EmployeeInformations")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication1.Models.DepartmentInformations", "DepartmentInformations")
                        .WithMany("EmployeeInformations")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication1.Models.DesignationInformations", "DesignationInformations")
                        .WithMany("EmployeeInformations")
                        .HasForeignKey("DesignationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication1.Models.TrackUpdateInformations", b =>
                {
                    b.HasOne("WebApplication1.Models.UserInformation", "UserInformation")
                        .WithMany("TrackUpdateInformations")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication1.Models.UnitInformations", b =>
                {
                    b.HasOne("WebApplication1.Models.UserInformation", "UserInformation")
                        .WithMany("UnitInformations")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication1.Models.UserInformation", b =>
                {
                    b.HasOne("WebApplication1.Models.GenderInformations", "Gender")
                        .WithMany("UserInformations")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}