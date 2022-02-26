using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class HeadAccountCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ControlAccountName",
                table: "ControlAccountInformations",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "HeadAccountsInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HeadAccountTitle = table.Column<string>(maxLength: 100, nullable: false),
                    Code = table.Column<int>(nullable: false),
                    ControlAccountId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadAccountsInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeadAccountsInformations_ControlAccountInformations_ControlAccountId",
                        column: x => x.ControlAccountId,
                        principalTable: "ControlAccountInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HeadAccountsInformations_UserInformations_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UserInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

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

            migrationBuilder.InsertData(
                table: "HeadAccountsInformations",
                columns: new[] { "Id", "Code", "ControlAccountId", "CreatedBy", "CreatedDate", "HeadAccountTitle", "IsActive" },
                values: new object[] { 1, 1001, 1, 1, new DateTime(2022, 2, 23, 22, 2, 7, 482, DateTimeKind.Local), "Current Assets", true });

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

            migrationBuilder.CreateIndex(
                name: "IX_HeadAccountsInformations_ControlAccountId",
                table: "HeadAccountsInformations",
                column: "ControlAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadAccountsInformations_CreatedBy",
                table: "HeadAccountsInformations",
                column: "CreatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeadAccountsInformations");

            migrationBuilder.AlterColumn<string>(
                name: "ControlAccountName",
                table: "ControlAccountInformations",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "BloodGroupInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 20, 43, 52, 562, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "ControlAccountInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 20, 43, 52, 571, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomerInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 20, 43, 52, 559, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DepartmentInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 20, 43, 52, 543, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DesignationInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 20, 43, 52, 551, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "EmployeeInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateofBirth", "DrivingLicienceExpiry", "HireDate", "IdCardExpiry", "PassportExpiry", "VisaExpiry" },
                values: new object[] { new DateTime(2022, 2, 23, 20, 43, 52, 566, DateTimeKind.Local), new DateTime(2022, 2, 23, 20, 43, 52, 566, DateTimeKind.Local), new DateTime(2022, 2, 23, 20, 43, 52, 567, DateTimeKind.Local), new DateTime(2022, 2, 23, 20, 43, 52, 567, DateTimeKind.Local), new DateTime(2022, 2, 23, 20, 43, 52, 567, DateTimeKind.Local), new DateTime(2022, 2, 23, 20, 43, 52, 567, DateTimeKind.Local), new DateTime(2022, 2, 23, 20, 43, 52, 567, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ProductInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 20, 43, 52, 554, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrackUpdateInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 20, 43, 52, 569, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UnitInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 20, 43, 52, 553, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 20, 43, 52, 542, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VehicleInformation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "InsuranceExpiry", "MulkiyaExpiry" },
                values: new object[] { new DateTime(2022, 2, 23, 20, 43, 52, 550, DateTimeKind.Local), new DateTime(2022, 2, 23, 20, 43, 52, 550, DateTimeKind.Local), new DateTime(2022, 2, 23, 20, 43, 52, 550, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "VehicleTypeInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 20, 43, 52, 562, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VenderInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 20, 43, 52, 562, DateTimeKind.Local));
        }
    }
}
