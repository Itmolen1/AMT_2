using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class EmployeesSeedCreatd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    GenderId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    EmergencyContactNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DateofBirth = table.Column<DateTime>(nullable: false),
                    HireDate = table.Column<DateTime>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: false),
                    BloodGroupId = table.Column<int>(nullable: false),
                    DesignationId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInformations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EmployeeInformations",
                columns: new[] { "Id", "Address", "Age", "BloodGroupId", "CreatedBy", "CreatedDate", "DateofBirth", "DepartmentId", "Description", "DesignationId", "EmailAddress", "EmergencyContactNumber", "GenderId", "HireDate", "ImageUrl", "IsActive", "MobileNumber", "Name" },
                values: new object[] { 1, "jos 10 faren street s6, no 1099", 25, 1, 1, new DateTime(2022, 2, 18, 18, 41, 6, 620, DateTimeKind.Local), new DateTime(2022, 2, 18, 18, 41, 6, 620, DateTimeKind.Local), 1, "this is test Employee From Seed", 1, "test@gmail.com", "64648464412", 1, new DateTime(2022, 2, 18, 18, 41, 6, 620, DateTimeKind.Local), "jas.jpg", true, "1231464612", "Test Name" });

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 18, 18, 41, 6, 619, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeInformations");

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 18, 18, 38, 35, 968, DateTimeKind.Local));
        }
    }
}
