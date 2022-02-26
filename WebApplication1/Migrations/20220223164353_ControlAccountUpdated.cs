using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class ControlAccountUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ControlAccountName",
                table: "ControlAccountInformations",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "ControlAccountInformations",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "Code", "CreatedDate" },
                values: new object[] { 1001, new DateTime(2022, 2, 23, 20, 43, 52, 571, DateTimeKind.Local) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "ControlAccountInformations");

            migrationBuilder.AlterColumn<string>(
                name: "ControlAccountName",
                table: "ControlAccountInformations",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "BloodGroupInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 20, 36, 22, 118, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "ControlAccountInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 23, 20, 36, 22, 169, DateTimeKind.Local));

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
        }
    }
}
