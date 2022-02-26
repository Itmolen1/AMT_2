using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class QuotationCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuotationInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    TotalAmount = table.Column<float>(nullable: true),
                    VAT = table.Column<float>(nullable: true),
                    GrandTotalAmount = table.Column<float>(nullable: true),
                    TermCondition = table.Column<string>(maxLength: 4000, nullable: true),
                    CustomerNote = table.Column<string>(maxLength: 4000, nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    QuotationNumber = table.Column<int>(nullable: false),
                    ISConverted = table.Column<bool>(nullable: false),
                    IsNeedSignature = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuotationInformation_UserInformations_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UserInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_QuotationInformation_CustomerInformations_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });
            
            
            migrationBuilder.UpdateData(
                table: "BloodGroupInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 25, 22, 248, DateTimeKind.Local));
            
            migrationBuilder.UpdateData(
                table: "CustomerInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 25, 22, 243, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DepartmentInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 25, 22, 209, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DesignationInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 25, 22, 223, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "EmployeeInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateofBirth", "DrivingLicienceExpiry", "HireDate", "IdCardExpiry", "PassportExpiry", "VisaExpiry" },
                values: new object[] { new DateTime(2022, 2, 26, 13, 25, 22, 259, DateTimeKind.Local), new DateTime(2022, 2, 26, 13, 25, 22, 259, DateTimeKind.Local), new DateTime(2022, 2, 26, 13, 25, 22, 260, DateTimeKind.Local), new DateTime(2022, 2, 26, 13, 25, 22, 260, DateTimeKind.Local), new DateTime(2022, 2, 26, 13, 25, 22, 260, DateTimeKind.Local), new DateTime(2022, 2, 26, 13, 25, 22, 260, DateTimeKind.Local), new DateTime(2022, 2, 26, 13, 25, 22, 260, DateTimeKind.Local) });
            
            migrationBuilder.UpdateData(
                table: "ProductInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 25, 22, 231, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "QuotationInformation",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "CustomerId", "CustomerNote", "DueDate", "FromDate", "GrandTotalAmount", "ISConverted", "IsActive", "IsNeedSignature", "QuotationNumber", "TermCondition", "TotalAmount", "VAT" },
                values: new object[] { 1, 1, new DateTime(2022, 2, 26, 13, 25, 22, 303, DateTimeKind.Local), 1, "This is test from seed", new DateTime(2022, 2, 26, 13, 25, 22, 302, DateTimeKind.Local), new DateTime(2022, 2, 26, 13, 25, 22, 302, DateTimeKind.Local), 105f, false, true, false, 1232154545, "This is Term Condition from seed", 100f, 5f });

            migrationBuilder.UpdateData(
                table: "TrackUpdateInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 25, 22, 265, DateTimeKind.Local));
                     
            migrationBuilder.UpdateData(
                table: "UnitInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 25, 22, 226, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 25, 22, 208, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VehicleInformation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "InsuranceExpiry", "MulkiyaExpiry" },
                values: new object[] { new DateTime(2022, 2, 26, 13, 25, 22, 222, DateTimeKind.Local), new DateTime(2022, 2, 26, 13, 25, 22, 223, DateTimeKind.Local), new DateTime(2022, 2, 26, 13, 25, 22, 223, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "VehicleTypeInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 25, 22, 249, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VenderInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 25, 22, 248, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_QuotationInformation_CreatedBy",
                table: "QuotationInformation",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationInformation_CustomerId",
                table: "QuotationInformation",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuotationInformation");

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
    }
}
