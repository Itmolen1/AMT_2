using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class BloodGroupAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodGroupInformations",
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
                    table.PrimaryKey("PK_BloodGroupInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodGroupInformations_UserInformations_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UserInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BloodGroupInformations",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "Name" },
                values: new object[] { 1, 1, new DateTime(2022, 2, 19, 21, 43, 22, 922, DateTimeKind.Local), true, "A+" });

            migrationBuilder.UpdateData(
                table: "DepartmentInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 19, 21, 43, 22, 910, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DesignationInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 19, 21, 43, 22, 918, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrackUpdateInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 19, 21, 43, 22, 930, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 19, 21, 43, 22, 910, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "EmployeeInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateofBirth", "HireDate" },
                values: new object[] { new DateTime(2022, 2, 19, 21, 43, 22, 926, DateTimeKind.Local), new DateTime(2022, 2, 19, 21, 43, 22, 926, DateTimeKind.Local), new DateTime(2022, 2, 19, 21, 43, 22, 926, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformations_BloodGroupId",
                table: "EmployeeInformations",
                column: "BloodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodGroupInformations_CreatedBy",
                table: "BloodGroupInformations",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeInformations_BloodGroupInformations_BloodGroupId",
                table: "EmployeeInformations",
                column: "BloodGroupId",
                principalTable: "BloodGroupInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeInformations_BloodGroupInformations_BloodGroupId",
                table: "EmployeeInformations");

            migrationBuilder.DropTable(
                name: "BloodGroupInformations");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeInformations_BloodGroupId",
                table: "EmployeeInformations");

            migrationBuilder.UpdateData(
                table: "DepartmentInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 19, 19, 49, 6, 592, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DesignationInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 19, 19, 49, 6, 596, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "EmployeeInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateofBirth", "HireDate" },
                values: new object[] { new DateTime(2022, 2, 19, 19, 49, 6, 604, DateTimeKind.Local), new DateTime(2022, 2, 19, 19, 49, 6, 604, DateTimeKind.Local), new DateTime(2022, 2, 19, 19, 49, 6, 604, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TrackUpdateInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 19, 19, 49, 6, 610, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 19, 19, 49, 6, 591, DateTimeKind.Local));
        }
    }
}
