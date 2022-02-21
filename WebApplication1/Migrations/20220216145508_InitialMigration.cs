using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GenderName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(maxLength: 100, nullable: false),
                    UserName = table.Column<string>(maxLength: 200, nullable: false),
                    UserPassword = table.Column<string>(maxLength: 50, nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInformations_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GenderName = table.Column<string>(nullable: true),
                    UserInformationId = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    GenderInformationsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeInformations_Genders_GenderInformationsId",
                        column: x => x.GenderInformationsId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeInformations_UserInformations_UserInformationId",
                        column: x => x.UserInformationId,
                        principalTable: "UserInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "EmployeeInformations",
                columns: new[] { "Id", "CreatedBy", "GenderInformationsId", "GenderName", "UserInformationId" },
                values: new object[] { 1, 1, null, null, null });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "GenderName" },
                values: new object[] { 1, "Male" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "GenderName" },
                values: new object[] { 2, "Female" });

            migrationBuilder.InsertData(
                table: "UserInformations",
                columns: new[] { "Id", "CreatedDate", "FullName", "GenderId", "ImageUrl", "IsActive", "UserName", "UserPassword" },
                values: new object[] { 1, new DateTime(2022, 2, 16, 18, 55, 8, 471, DateTimeKind.Local), "Admin", 1, null, true, "admin@gmail.com", "12345678" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformations_GenderInformationsId",
                table: "EmployeeInformations",
                column: "GenderInformationsId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInformations_UserInformationId",
                table: "EmployeeInformations",
                column: "UserInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInformations_GenderId",
                table: "UserInformations",
                column: "GenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeInformations");

            migrationBuilder.DropTable(
                name: "UserInformations");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
