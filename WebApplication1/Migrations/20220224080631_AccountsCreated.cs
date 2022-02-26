using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class AccountsCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountsInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountTitle = table.Column<string>(maxLength: 200, nullable: false),
                    Code = table.Column<int>(nullable: false),
                    HeadAccountId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountsInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountsInformations_UserInformations_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UserInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountsInformations_HeadAccountsInformations_HeadAccountId",
                        column: x => x.HeadAccountId,
                        principalTable: "HeadAccountsInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccountsInformations",
                columns: new[] { "Id", "AccountTitle", "Code", "CreatedBy", "CreatedDate", "HeadAccountId", "IsActive" },
                values: new object[] { 1, "Petty cash", 10001, 1, new DateTime(2022, 2, 24, 12, 6, 30, 293, DateTimeKind.Local), 1, true });

            migrationBuilder.UpdateData(
                table: "BloodGroupInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 12, 6, 30, 266, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "ControlAccountInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 12, 6, 30, 279, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomerInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 12, 6, 30, 263, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DepartmentInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 12, 6, 30, 236, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DesignationInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 12, 6, 30, 250, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "EmployeeInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateofBirth", "DrivingLicienceExpiry", "HireDate", "IdCardExpiry", "PassportExpiry", "VisaExpiry" },
                values: new object[] { new DateTime(2022, 2, 24, 12, 6, 30, 271, DateTimeKind.Local), new DateTime(2022, 2, 24, 12, 6, 30, 271, DateTimeKind.Local), new DateTime(2022, 2, 24, 12, 6, 30, 271, DateTimeKind.Local), new DateTime(2022, 2, 24, 12, 6, 30, 271, DateTimeKind.Local), new DateTime(2022, 2, 24, 12, 6, 30, 271, DateTimeKind.Local), new DateTime(2022, 2, 24, 12, 6, 30, 271, DateTimeKind.Local), new DateTime(2022, 2, 24, 12, 6, 30, 271, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "HeadAccountsInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 12, 6, 30, 286, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "ProductInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 12, 6, 30, 256, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrackUpdateInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 12, 6, 30, 274, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UnitInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 12, 6, 30, 253, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 12, 6, 30, 235, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VehicleInformation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "InsuranceExpiry", "MulkiyaExpiry" },
                values: new object[] { new DateTime(2022, 2, 24, 12, 6, 30, 250, DateTimeKind.Local), new DateTime(2022, 2, 24, 12, 6, 30, 250, DateTimeKind.Local), new DateTime(2022, 2, 24, 12, 6, 30, 250, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "VehicleTypeInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 12, 6, 30, 266, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VenderInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 12, 6, 30, 265, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_AccountsInformations_CreatedBy",
                table: "AccountsInformations",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsInformations_HeadAccountId",
                table: "AccountsInformations",
                column: "HeadAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountsInformations");

            migrationBuilder.UpdateData(
                table: "BloodGroupInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 22, 2, 7, 455, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "ControlAccountInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 22, 2, 7, 475, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomerInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 22, 2, 7, 450, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DepartmentInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 22, 2, 7, 419, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DesignationInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 22, 2, 7, 430, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "EmployeeInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateofBirth", "DrivingLicienceExpiry", "HireDate", "IdCardExpiry", "PassportExpiry", "VisaExpiry" },
                values: new object[] { new DateTime(2022, 2, 23, 22, 2, 7, 466, DateTimeKind.Local), new DateTime(2022, 2, 23, 22, 2, 7, 466, DateTimeKind.Local), new DateTime(2022, 2, 23, 22, 2, 7, 467, DateTimeKind.Local), new DateTime(2022, 2, 23, 22, 2, 7, 467, DateTimeKind.Local), new DateTime(2022, 2, 23, 22, 2, 7, 467, DateTimeKind.Local), new DateTime(2022, 2, 23, 22, 2, 7, 467, DateTimeKind.Local), new DateTime(2022, 2, 23, 22, 2, 7, 467, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "HeadAccountsInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 22, 2, 7, 482, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "ProductInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 22, 2, 7, 438, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrackUpdateInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 22, 2, 7, 471, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UnitInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 22, 2, 7, 434, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 22, 2, 7, 418, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VehicleInformation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "InsuranceExpiry", "MulkiyaExpiry" },
                values: new object[] { new DateTime(2022, 2, 23, 22, 2, 7, 429, DateTimeKind.Local), new DateTime(2022, 2, 23, 22, 2, 7, 429, DateTimeKind.Local), new DateTime(2022, 2, 23, 22, 2, 7, 429, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "VehicleTypeInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 22, 2, 7, 456, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VenderInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 22, 2, 7, 455, DateTimeKind.Local));
        }
    }
}
