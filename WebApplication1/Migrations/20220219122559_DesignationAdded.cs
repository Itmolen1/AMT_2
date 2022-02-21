using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class DesignationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DepartmentInformations",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DesignationInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignationInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DesignationInformations_UserInformations_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UserInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "DepartmentInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 19, 16, 25, 59, 88, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "DesignationInformations",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "Name" },
                values: new object[] { 1, 1, new DateTime(2022, 2, 19, 16, 25, 59, 92, DateTimeKind.Local), true, "Driver" });

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 19, 16, 25, 59, 87, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "EmployeeInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateofBirth", "HireDate" },
                values: new object[] { new DateTime(2022, 2, 19, 16, 25, 59, 99, DateTimeKind.Local), new DateTime(2022, 2, 19, 16, 25, 59, 99, DateTimeKind.Local), new DateTime(2022, 2, 19, 16, 25, 59, 100, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformations_DesignationId",
                table: "EmployeeInformations",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignationInformations_CreatedBy",
                table: "DesignationInformations",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeInformations_DesignationInformations_DesignationId",
                table: "EmployeeInformations",
                column: "DesignationId",
                principalTable: "DesignationInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeInformations_DesignationInformations_DesignationId",
                table: "EmployeeInformations");

            migrationBuilder.DropTable(
                name: "DesignationInformations");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeInformations_DesignationId",
                table: "EmployeeInformations");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DepartmentInformations",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "DepartmentInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 18, 21, 7, 29, 267, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "EmployeeInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateofBirth", "HireDate" },
                values: new object[] { new DateTime(2022, 2, 18, 21, 7, 29, 270, DateTimeKind.Local), new DateTime(2022, 2, 18, 21, 7, 29, 271, DateTimeKind.Local), new DateTime(2022, 2, 18, 21, 7, 29, 271, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 18, 21, 7, 29, 267, DateTimeKind.Local));
        }
    }
}
