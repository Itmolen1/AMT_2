using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class EmpUserBindCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmployeeInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateofBirth", "HireDate" },
                values: new object[] { new DateTime(2022, 2, 18, 18, 44, 28, 84, DateTimeKind.Local), new DateTime(2022, 2, 18, 18, 44, 28, 84, DateTimeKind.Local), new DateTime(2022, 2, 18, 18, 44, 28, 84, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 18, 18, 44, 28, 82, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformations_CreatedBy",
                table: "EmployeeInformations",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeInformations_UserInformations_CreatedBy",
                table: "EmployeeInformations",
                column: "CreatedBy",
                principalTable: "UserInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeInformations_UserInformations_CreatedBy",
                table: "EmployeeInformations");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeInformations_CreatedBy",
                table: "EmployeeInformations");

            migrationBuilder.UpdateData(
                table: "EmployeeInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateofBirth", "HireDate" },
                values: new object[] { new DateTime(2022, 2, 18, 18, 41, 6, 620, DateTimeKind.Local), new DateTime(2022, 2, 18, 18, 41, 6, 620, DateTimeKind.Local), new DateTime(2022, 2, 18, 18, 41, 6, 620, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 18, 18, 41, 6, 619, DateTimeKind.Local));
        }
    }
}
