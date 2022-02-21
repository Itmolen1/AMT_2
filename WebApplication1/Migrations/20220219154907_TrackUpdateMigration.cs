using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class TrackUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrackUpdateInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UpdateInfo = table.Column<string>(nullable: true),
                    BeforeUpdate = table.Column<string>(nullable: true),
                    AfterUpdate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackUpdateInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackUpdateInformations_UserInformations_CreatedBy",
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

            migrationBuilder.InsertData(
                table: "TrackUpdateInformations",
                columns: new[] { "Id", "AfterUpdate", "BeforeUpdate", "CreatedBy", "CreatedDate", "IsActive", "UpdateInfo" },
                values: new object[] { 1, "Driver Name", "Driver", 1, new DateTime(2022, 2, 19, 19, 49, 6, 610, DateTimeKind.Local), true, "Driver Update to Driver Name" });

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 19, 19, 49, 6, 591, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_TrackUpdateInformations_CreatedBy",
                table: "TrackUpdateInformations",
                column: "CreatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackUpdateInformations");

            migrationBuilder.UpdateData(
                table: "DepartmentInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 19, 16, 25, 59, 88, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DesignationInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 19, 16, 25, 59, 92, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "EmployeeInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateofBirth", "HireDate" },
                values: new object[] { new DateTime(2022, 2, 19, 16, 25, 59, 99, DateTimeKind.Local), new DateTime(2022, 2, 19, 16, 25, 59, 99, DateTimeKind.Local), new DateTime(2022, 2, 19, 16, 25, 59, 100, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 19, 16, 25, 59, 87, DateTimeKind.Local));
        }
    }
}
