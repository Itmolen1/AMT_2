using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class VehicleCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlateNumber = table.Column<string>(maxLength: 20, nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    MulkiyaExpiry = table.Column<DateTime>(nullable: false),
                    InsuranceExpiry = table.Column<DateTime>(nullable: false),
                    TCNumber = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    RegisterdRegion = table.Column<string>(maxLength: 1000, nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    VehicleTypeId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleInformation_UserInformations_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UserInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_VehicleInformation_VehicleTypeInformations_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypeInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "BloodGroupInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 21, 18, 33, 29, 515, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomerInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 21, 18, 33, 29, 512, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DepartmentInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 21, 18, 33, 29, 489, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DesignationInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 21, 18, 33, 29, 500, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "EmployeeInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateofBirth", "HireDate" },
                values: new object[] { new DateTime(2022, 2, 21, 18, 33, 29, 519, DateTimeKind.Local), new DateTime(2022, 2, 21, 18, 33, 29, 519, DateTimeKind.Local), new DateTime(2022, 2, 21, 18, 33, 29, 520, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ProductInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 21, 18, 33, 29, 505, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrackUpdateInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 21, 18, 33, 29, 522, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UnitInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 21, 18, 33, 29, 502, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 21, 18, 33, 29, 488, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "VehicleInformation",
                columns: new[] { "Id", "Brand", "Color", "Comments", "CreatedBy", "CreatedDate", "InsuranceExpiry", "IsActive", "Model", "MulkiyaExpiry", "PlateNumber", "RegisterdRegion", "TCNumber", "VehicleTypeId" },
                values: new object[] { 1, "Toyota", "Red", "this from seed for test", 1, new DateTime(2022, 2, 21, 18, 33, 29, 499, DateTimeKind.Local), new DateTime(2022, 2, 21, 18, 33, 29, 499, DateTimeKind.Local), true, "2008", new DateTime(2022, 2, 21, 18, 33, 29, 499, DateTimeKind.Local), "2005", "Abu Dhabi", "13131", 1 });

            migrationBuilder.UpdateData(
                table: "VehicleTypeInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 21, 18, 33, 29, 515, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VenderInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 21, 18, 33, 29, 515, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_VehicleInformation_CreatedBy",
                table: "VehicleInformation",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleInformation_VehicleTypeId",
                table: "VehicleInformation",
                column: "VehicleTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleInformation");

            migrationBuilder.UpdateData(
                table: "BloodGroupInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 21, 15, 49, 50, 309, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomerInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 21, 15, 49, 50, 303, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DepartmentInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 21, 15, 49, 50, 268, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DesignationInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 21, 15, 49, 50, 278, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "EmployeeInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateofBirth", "HireDate" },
                values: new object[] { new DateTime(2022, 2, 21, 15, 49, 50, 320, DateTimeKind.Local), new DateTime(2022, 2, 21, 15, 49, 50, 320, DateTimeKind.Local), new DateTime(2022, 2, 21, 15, 49, 50, 321, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ProductInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 21, 15, 49, 50, 290, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrackUpdateInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 21, 15, 49, 50, 324, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UnitInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 21, 15, 49, 50, 284, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 21, 15, 49, 50, 268, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VehicleTypeInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 21, 15, 49, 50, 310, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VenderInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 21, 15, 49, 50, 308, DateTimeKind.Local));
        }
    }
}
