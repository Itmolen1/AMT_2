using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class CustomerCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(maxLength: 100, nullable: false),
                    TRNNumber = table.Column<long>(nullable: false),
                    ContactPersonName = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    LandLine = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Address = table.Column<string>(maxLength: 300, nullable: true),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerInformations_UserInformations_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UserInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "BloodGroupInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 20, 19, 35, 33, 176, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "CustomerInformations",
                columns: new[] { "Id", "Address", "Area", "CompanyName", "ContactPersonName", "Country", "CreatedBy", "CreatedDate", "Description", "Email", "IsActive", "LandLine", "MobileNumber", "State", "TRNNumber" },
                values: new object[] { 1, "nest 18, street k5 Allon", "Mufraq", "Test Name", "Seed Name", "UAE", 1, new DateTime(2022, 2, 20, 19, 35, 33, 175, DateTimeKind.Local), "this is test description from seed", "this@test.com", true, "34564613564", "121313454112", "Abu Dhabi", 123456789123456L });

            migrationBuilder.UpdateData(
                table: "DepartmentInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 20, 19, 35, 33, 148, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DesignationInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 20, 19, 35, 33, 156, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "EmployeeInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateofBirth", "HireDate" },
                values: new object[] { new DateTime(2022, 2, 20, 19, 35, 33, 180, DateTimeKind.Local), new DateTime(2022, 2, 20, 19, 35, 33, 180, DateTimeKind.Local), new DateTime(2022, 2, 20, 19, 35, 33, 181, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ProductInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 20, 19, 35, 33, 164, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrackUpdateInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 20, 19, 35, 33, 184, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UnitInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 20, 19, 35, 33, 160, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 20, 19, 35, 33, 148, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInformations_CreatedBy",
                table: "CustomerInformations",
                column: "CreatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerInformations");

            migrationBuilder.UpdateData(
                table: "BloodGroupInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 20, 12, 27, 45, 158, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DepartmentInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 20, 12, 27, 45, 136, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DesignationInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 20, 12, 27, 45, 144, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "EmployeeInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateofBirth", "HireDate" },
                values: new object[] { new DateTime(2022, 2, 20, 12, 27, 45, 162, DateTimeKind.Local), new DateTime(2022, 2, 20, 12, 27, 45, 162, DateTimeKind.Local), new DateTime(2022, 2, 20, 12, 27, 45, 163, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ProductInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 20, 12, 27, 45, 151, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrackUpdateInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 20, 12, 27, 45, 166, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UnitInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 20, 12, 27, 45, 148, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 20, 12, 27, 45, 135, DateTimeKind.Local));
        }
    }
}
