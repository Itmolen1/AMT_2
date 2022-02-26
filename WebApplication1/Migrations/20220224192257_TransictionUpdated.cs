using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class TransictionUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransictionIdentity",
                table: "TransictionInformations",
                nullable: false,
                defaultValue: 0);
            
            migrationBuilder.UpdateData(
                table: "BloodGroupInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 23, 22, 56, 740, DateTimeKind.Local));
            
            migrationBuilder.UpdateData(
                table: "CustomerInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 23, 22, 56, 737, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DepartmentInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 23, 22, 56, 720, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DesignationInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 23, 22, 56, 727, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "EmployeeInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateofBirth", "DrivingLicienceExpiry", "HireDate", "IdCardExpiry", "PassportExpiry", "VisaExpiry" },
                values: new object[] { new DateTime(2022, 2, 24, 23, 22, 56, 745, DateTimeKind.Local), new DateTime(2022, 2, 24, 23, 22, 56, 745, DateTimeKind.Local), new DateTime(2022, 2, 24, 23, 22, 56, 745, DateTimeKind.Local), new DateTime(2022, 2, 24, 23, 22, 56, 745, DateTimeKind.Local), new DateTime(2022, 2, 24, 23, 22, 56, 745, DateTimeKind.Local), new DateTime(2022, 2, 24, 23, 22, 56, 745, DateTimeKind.Local), new DateTime(2022, 2, 24, 23, 22, 56, 745, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ProductInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 23, 22, 56, 732, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrackUpdateInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 23, 22, 56, 747, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TransictionInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ForDate", "TransictionIdentity" },
                values: new object[] { new DateTime(2022, 2, 24, 23, 22, 56, 759, DateTimeKind.Local), new DateTime(2022, 2, 24, 23, 22, 56, 759, DateTimeKind.Local), 1245654284 });

            migrationBuilder.UpdateData(
                table: "TransictionInformations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ForDate", "TransictionIdentity" },
                values: new object[] { new DateTime(2022, 2, 24, 23, 22, 56, 759, DateTimeKind.Local), new DateTime(2022, 2, 24, 23, 22, 56, 759, DateTimeKind.Local), 1245654284 });

            migrationBuilder.UpdateData(
                table: "UnitInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 23, 22, 56, 730, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 23, 22, 56, 720, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VehicleInformation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "InsuranceExpiry", "MulkiyaExpiry" },
                values: new object[] { new DateTime(2022, 2, 24, 23, 22, 56, 727, DateTimeKind.Local), new DateTime(2022, 2, 24, 23, 22, 56, 727, DateTimeKind.Local), new DateTime(2022, 2, 24, 23, 22, 56, 727, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "VehicleTypeInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 23, 22, 56, 740, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VenderInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 23, 22, 56, 739, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransictionIdentity",
                table: "TransictionInformations");

            migrationBuilder.UpdateData(
                table: "BloodGroupInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 19, 34, 53, 538, DateTimeKind.Local));
            
            migrationBuilder.UpdateData(
                table: "CustomerInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 19, 34, 53, 535, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DepartmentInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 19, 34, 53, 519, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DesignationInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 19, 34, 53, 526, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "EmployeeInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateofBirth", "DrivingLicienceExpiry", "HireDate", "IdCardExpiry", "PassportExpiry", "VisaExpiry" },
                values: new object[] { new DateTime(2022, 2, 24, 19, 34, 53, 542, DateTimeKind.Local), new DateTime(2022, 2, 24, 19, 34, 53, 542, DateTimeKind.Local), new DateTime(2022, 2, 24, 19, 34, 53, 543, DateTimeKind.Local), new DateTime(2022, 2, 24, 19, 34, 53, 542, DateTimeKind.Local), new DateTime(2022, 2, 24, 19, 34, 53, 542, DateTimeKind.Local), new DateTime(2022, 2, 24, 19, 34, 53, 543, DateTimeKind.Local), new DateTime(2022, 2, 24, 19, 34, 53, 543, DateTimeKind.Local) });
            
            migrationBuilder.UpdateData(
                table: "ProductInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 19, 34, 53, 531, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrackUpdateInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 19, 34, 53, 544, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TransictionInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ForDate" },
                values: new object[] { new DateTime(2022, 2, 24, 19, 34, 53, 556, DateTimeKind.Local), new DateTime(2022, 2, 24, 19, 34, 53, 556, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TransictionInformations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ForDate" },
                values: new object[] { new DateTime(2022, 2, 24, 19, 34, 53, 556, DateTimeKind.Local), new DateTime(2022, 2, 24, 19, 34, 53, 556, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "UnitInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 19, 34, 53, 528, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 19, 34, 53, 519, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VehicleInformation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "InsuranceExpiry", "MulkiyaExpiry" },
                values: new object[] { new DateTime(2022, 2, 24, 19, 34, 53, 526, DateTimeKind.Local), new DateTime(2022, 2, 24, 19, 34, 53, 526, DateTimeKind.Local), new DateTime(2022, 2, 24, 19, 34, 53, 526, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "VehicleTypeInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 19, 34, 53, 538, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VenderInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 19, 34, 53, 538, DateTimeKind.Local));
        }
    }
}
