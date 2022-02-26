using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class QuotationDetailsCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuotationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuotationId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    UnitPrice = table.Column<float>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Total = table.Column<float>(nullable: true),
                    VAT = table.Column<float>(nullable: true),
                    SubTotal = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuotationDetails_ProductInfos_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ProductInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_QuotationDetails_QuotationInformation_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "QuotationInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_QuotationDetails_UnitInformations_UnitId",
                        column: x => x.UnitId,
                        principalTable: "UnitInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });
            
            migrationBuilder.UpdateData(
                table: "BloodGroupInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 59, 28, 452, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomerInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 59, 28, 446, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DepartmentInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 59, 28, 407, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DesignationInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 59, 28, 423, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "EmployeeInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateofBirth", "DrivingLicienceExpiry", "HireDate", "IdCardExpiry", "PassportExpiry", "VisaExpiry" },
                values: new object[] { new DateTime(2022, 2, 26, 13, 59, 28, 462, DateTimeKind.Local), new DateTime(2022, 2, 26, 13, 59, 28, 462, DateTimeKind.Local), new DateTime(2022, 2, 26, 13, 59, 28, 463, DateTimeKind.Local), new DateTime(2022, 2, 26, 13, 59, 28, 462, DateTimeKind.Local), new DateTime(2022, 2, 26, 13, 59, 28, 462, DateTimeKind.Local), new DateTime(2022, 2, 26, 13, 59, 28, 463, DateTimeKind.Local), new DateTime(2022, 2, 26, 13, 59, 28, 463, DateTimeKind.Local) });
                       
            migrationBuilder.UpdateData(
                table: "ProductInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 59, 28, 432, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "QuotationDetails",
                columns: new[] { "Id", "Description", "ItemId", "Quantity", "QuotationId", "SubTotal", "Total", "UnitId", "UnitPrice", "VAT" },
                values: new object[] { 1, "this one item from seed", 1, 5, 1, 105f, 100f, 1, 20f, 5f });

            migrationBuilder.UpdateData(
                table: "QuotationInformation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DueDate", "FromDate" },
                values: new object[] { new DateTime(2022, 2, 26, 13, 59, 28, 523, DateTimeKind.Local), new DateTime(2022, 2, 26, 13, 59, 28, 522, DateTimeKind.Local), new DateTime(2022, 2, 26, 13, 59, 28, 522, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TrackUpdateInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 59, 28, 467, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UnitInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 59, 28, 427, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 59, 28, 407, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VehicleInformation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "InsuranceExpiry", "MulkiyaExpiry" },
                values: new object[] { new DateTime(2022, 2, 26, 13, 59, 28, 421, DateTimeKind.Local), new DateTime(2022, 2, 26, 13, 59, 28, 422, DateTimeKind.Local), new DateTime(2022, 2, 26, 13, 59, 28, 422, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "VehicleTypeInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 59, 28, 452, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VenderInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 59, 28, 451, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_QuotationDetails_ItemId",
                table: "QuotationDetails",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationDetails_QuotationId",
                table: "QuotationDetails",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationDetails_UnitId",
                table: "QuotationDetails",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuotationDetails");
                        
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

            migrationBuilder.UpdateData(
                table: "QuotationInformation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DueDate", "FromDate" },
                values: new object[] { new DateTime(2022, 2, 26, 13, 25, 22, 303, DateTimeKind.Local), new DateTime(2022, 2, 26, 13, 25, 22, 302, DateTimeKind.Local), new DateTime(2022, 2, 26, 13, 25, 22, 302, DateTimeKind.Local) });

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
        }
    }
}
