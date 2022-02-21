using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class DepartmentCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentInformations_UserInformations_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UserInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DepartmentInformations",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "Name" },
                values: new object[] { 1, 1, new DateTime(2022, 2, 18, 21, 7, 29, 267, DateTimeKind.Local), true, "Accounting" });

            migrationBuilder.UpdateData(
                table: "UserInformations",
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

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformations_DepartmentId",
                table: "EmployeeInformations",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentInformations_CreatedBy",
                table: "DepartmentInformations",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeInformations_DepartmentInformations_DepartmentId",
                table: "EmployeeInformations",
                column: "DepartmentId",
                principalTable: "DepartmentInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeInformations_DepartmentInformations_DepartmentId",
                table: "EmployeeInformations");

            migrationBuilder.DropTable(
                name: "DepartmentInformations");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeInformations_DepartmentId",
                table: "EmployeeInformations");

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
        }
    }
}
