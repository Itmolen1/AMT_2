using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class ControlAccountCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControlAccountInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ControlAccountName = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlAccountInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlAccountInformations_UserInformations_CreatedBy",
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
                value: new DateTime(2022, 2, 23, 20, 36, 22, 118, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "ControlAccountInformations",
                columns: new[] { "Id", "ControlAccountName", "CreatedBy", "CreatedDate", "IsActive" },
                values: new object[] { 1, "ASSETS", 1, new DateTime(2022, 2, 23, 20, 36, 22, 169, DateTimeKind.Local), true });

            migrationBuilder.UpdateData(
                table: "CustomerInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 20, 36, 22, 115, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DepartmentInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 20, 36, 22, 92, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DesignationInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 20, 36, 22, 102, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "EmployeeInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateofBirth", "DrivingLicienceExpiry", "HireDate", "IdCardExpiry", "PassportExpiry", "VisaExpiry" },
                values: new object[] { new DateTime(2022, 2, 23, 20, 36, 22, 161, DateTimeKind.Local), new DateTime(2022, 2, 23, 20, 36, 22, 161, DateTimeKind.Local), new DateTime(2022, 2, 23, 20, 36, 22, 162, DateTimeKind.Local), new DateTime(2022, 2, 23, 20, 36, 22, 161, DateTimeKind.Local), new DateTime(2022, 2, 23, 20, 36, 22, 162, DateTimeKind.Local), new DateTime(2022, 2, 23, 20, 36, 22, 162, DateTimeKind.Local), new DateTime(2022, 2, 23, 20, 36, 22, 162, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ProductInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 20, 36, 22, 108, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrackUpdateInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 20, 36, 22, 166, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UnitInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 20, 36, 22, 106, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 20, 36, 22, 92, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VehicleInformation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "InsuranceExpiry", "MulkiyaExpiry" },
                values: new object[] { new DateTime(2022, 2, 23, 20, 36, 22, 101, DateTimeKind.Local), new DateTime(2022, 2, 23, 20, 36, 22, 102, DateTimeKind.Local), new DateTime(2022, 2, 23, 20, 36, 22, 102, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "VehicleTypeInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 20, 36, 22, 118, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VenderInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 20, 36, 22, 117, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_ControlAccountInformations_CreatedBy",
                table: "ControlAccountInformations",
                column: "CreatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControlAccountInformations");

            migrationBuilder.UpdateData(
                table: "BloodGroupInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 22, 12, 33, 32, 330, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomerInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 22, 12, 33, 32, 326, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DepartmentInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 22, 12, 33, 32, 292, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DesignationInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 22, 12, 33, 32, 307, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "EmployeeInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateofBirth", "DrivingLicienceExpiry", "HireDate", "IdCardExpiry", "PassportExpiry", "VisaExpiry" },
                values: new object[] { new DateTime(2022, 2, 22, 12, 33, 32, 339, DateTimeKind.Local), new DateTime(2022, 2, 22, 12, 33, 32, 339, DateTimeKind.Local), new DateTime(2022, 2, 22, 12, 33, 32, 340, DateTimeKind.Local), new DateTime(2022, 2, 22, 12, 33, 32, 339, DateTimeKind.Local), new DateTime(2022, 2, 22, 12, 33, 32, 339, DateTimeKind.Local), new DateTime(2022, 2, 22, 12, 33, 32, 340, DateTimeKind.Local), new DateTime(2022, 2, 22, 12, 33, 32, 340, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ProductInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 22, 12, 33, 32, 315, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrackUpdateInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 22, 12, 33, 32, 344, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UnitInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 22, 12, 33, 32, 311, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 22, 12, 33, 32, 292, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VehicleInformation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "InsuranceExpiry", "MulkiyaExpiry" },
                values: new object[] { new DateTime(2022, 2, 22, 12, 33, 32, 306, DateTimeKind.Local), new DateTime(2022, 2, 22, 12, 33, 32, 307, DateTimeKind.Local), new DateTime(2022, 2, 22, 12, 33, 32, 307, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "VehicleTypeInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 22, 12, 33, 32, 331, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VenderInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 22, 12, 33, 32, 330, DateTimeKind.Local));
        }
    }
}
