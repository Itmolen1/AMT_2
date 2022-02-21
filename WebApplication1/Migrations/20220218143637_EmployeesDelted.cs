using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class EmployeesDelted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeInformations");

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 18, 18, 36, 36, 825, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    Age = table.Column<int>(nullable: false),
                    BloodGroupId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DateofBirth = table.Column<DateTime>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    DesignationId = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    EmergencyContactNumber = table.Column<string>(nullable: true),
                    GenderId = table.Column<int>(nullable: false),
                    GenderInformationsId = table.Column<int>(nullable: true),
                    HireDate = table.Column<DateTime>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    MobileNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeInformations_Genders_GenderInformationsId",
                        column: x => x.GenderInformationsId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "EmployeeInformations",
                columns: new[] { "Id", "Address", "Age", "BloodGroupId", "CreatedBy", "CreatedDate", "DateofBirth", "DepartmentId", "Description", "DesignationId", "EmailAddress", "EmergencyContactNumber", "GenderId", "GenderInformationsId", "HireDate", "ImageUrl", "IsActive", "MobileNumber", "Name" },
                values: new object[] { 1, "jos 10 faren street s6, no 1099", 25, 1, 1, new DateTime(2022, 2, 18, 18, 33, 55, 559, DateTimeKind.Local), new DateTime(2022, 2, 18, 18, 33, 55, 559, DateTimeKind.Local), 1, "this is test Employee From Seed", 1, "test@gmail.com", "64648464412", 1, null, new DateTime(2022, 2, 18, 18, 33, 55, 559, DateTimeKind.Local), "jas.jpg", true, "1231464612", "Test Name" });

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 18, 18, 33, 55, 558, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformations_GenderInformationsId",
                table: "EmployeeInformations",
                column: "GenderInformationsId");
        }
    }
}
