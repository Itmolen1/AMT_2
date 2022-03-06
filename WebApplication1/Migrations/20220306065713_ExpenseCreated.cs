using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class ExpenseCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentTypes_UserInformations_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UserInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VenderId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    TotalAmount = table.Column<float>(nullable: true),
                    VAT = table.Column<float>(nullable: true),
                    GrandTotalAmount = table.Column<float>(nullable: true),
                    SpecialNote = table.Column<string>(maxLength: 4000, nullable: true),
                    ExpenseDate = table.Column<DateTime>(nullable: false),
                    PaymentType = table.Column<int>(nullable: false),
                    ExpenseNumber = table.Column<int>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseInformations_UserInformations_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UserInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ExpenseInformations_EmployeeInformations_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ExpenseInformations_PaymentTypes_PaymentType",
                        column: x => x.PaymentType,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ExpenseInformations_VenderInformations_VenderId",
                        column: x => x.VenderId,
                        principalTable: "VenderInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseDetailsInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExpenseId = table.Column<int>(nullable: false),
                    OnDate = table.Column<DateTime>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    ExpenseRefrenceId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false),
                    GeneralExpenseId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ExpenseType = table.Column<int>(nullable: false),
                    SubTotal = table.Column<float>(nullable: true),
                    VAT = table.Column<float>(nullable: true),
                    NetTotal = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseDetailsInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseDetailsInformations_EmployeeInformations_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ExpenseDetailsInformations_ExpenseInformations_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "ExpenseInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ExpenseDetailsInformations_ProductInfos_GeneralExpenseId",
                        column: x => x.GeneralExpenseId,
                        principalTable: "ProductInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ExpenseDetailsInformations_VehicleInformation_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VehicleInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "AccountsInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 6, 10, 57, 12, 5, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "BloodGroupInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 6, 10, 57, 11, 956, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "ControlAccountInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 6, 10, 57, 11, 976, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "CustomerInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 6, 10, 57, 11, 929, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DepartmentInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 6, 10, 57, 11, 875, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DesignationInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 6, 10, 57, 11, 904, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "EmployeeInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateofBirth", "DrivingLicienceExpiry", "HireDate", "IdCardExpiry", "PassportExpiry", "VisaExpiry" },
                values: new object[] { new DateTime(2022, 3, 6, 10, 57, 11, 966, DateTimeKind.Local), new DateTime(2022, 3, 6, 10, 57, 11, 966, DateTimeKind.Local), new DateTime(2022, 3, 6, 10, 57, 11, 967, DateTimeKind.Local), new DateTime(2022, 3, 6, 10, 57, 11, 966, DateTimeKind.Local), new DateTime(2022, 3, 6, 10, 57, 11, 967, DateTimeKind.Local), new DateTime(2022, 3, 6, 10, 57, 11, 967, DateTimeKind.Local), new DateTime(2022, 3, 6, 10, 57, 11, 967, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "HeadAccountsInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 6, 10, 57, 11, 998, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "TypeName" },
                values: new object[] { 1, 1, new DateTime(2022, 3, 6, 10, 57, 12, 32, DateTimeKind.Local), true, "Cash" });

            migrationBuilder.UpdateData(
                table: "ProductInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 6, 10, 57, 11, 914, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "QuotationInformation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DueDate", "FromDate" },
                values: new object[] { new DateTime(2022, 3, 6, 10, 57, 12, 20, DateTimeKind.Local), new DateTime(2022, 3, 6, 10, 57, 12, 19, DateTimeKind.Local), new DateTime(2022, 3, 6, 10, 57, 12, 19, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TrackUpdateInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 6, 10, 57, 11, 971, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TransictionInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ForDate" },
                values: new object[] { new DateTime(2022, 3, 6, 10, 57, 12, 12, DateTimeKind.Local), new DateTime(2022, 3, 6, 10, 57, 12, 12, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TransictionInformations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ForDate" },
                values: new object[] { new DateTime(2022, 3, 6, 10, 57, 12, 12, DateTimeKind.Local), new DateTime(2022, 3, 6, 10, 57, 12, 12, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "UnitInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 6, 10, 57, 11, 910, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 6, 10, 57, 11, 875, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VehicleInformation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "InsuranceExpiry", "MulkiyaExpiry" },
                values: new object[] { new DateTime(2022, 3, 6, 10, 57, 11, 903, DateTimeKind.Local), new DateTime(2022, 3, 6, 10, 57, 11, 904, DateTimeKind.Local), new DateTime(2022, 3, 6, 10, 57, 11, 904, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "VehicleTypeInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 6, 10, 57, 11, 957, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VenderInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 6, 10, 57, 11, 956, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "ExpenseInformations",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "EmployeeId", "ExpenseDate", "ExpenseNumber", "GrandTotalAmount", "IsActive", "IsApproved", "PaymentType", "SpecialNote", "TotalAmount", "VAT", "VenderId" },
                values: new object[] { 1, 1, new DateTime(2022, 3, 6, 10, 57, 12, 58, DateTimeKind.Local), 1, new DateTime(2022, 3, 6, 10, 57, 12, 57, DateTimeKind.Local), 100121, 210f, true, false, 1, "This is note from seed", 200f, 10f, 1 });

            migrationBuilder.InsertData(
                table: "ExpenseDetailsInformations",
                columns: new[] { "Id", "Category", "Description", "EmployeeId", "ExpenseId", "ExpenseRefrenceId", "ExpenseType", "GeneralExpenseId", "NetTotal", "OnDate", "SubTotal", "VAT", "VehicleId" },
                values: new object[] { 1, "Employee", "this is employee expense", 1, 1, 1, 0, 1, 105f, new DateTime(2022, 3, 6, 10, 57, 12, 58, DateTimeKind.Local), 100f, 5f, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseDetailsInformations_EmployeeId",
                table: "ExpenseDetailsInformations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseDetailsInformations_ExpenseId",
                table: "ExpenseDetailsInformations",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseDetailsInformations_GeneralExpenseId",
                table: "ExpenseDetailsInformations",
                column: "GeneralExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseDetailsInformations_VehicleId",
                table: "ExpenseDetailsInformations",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseInformations_CreatedBy",
                table: "ExpenseInformations",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseInformations_EmployeeId",
                table: "ExpenseInformations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseInformations_PaymentType",
                table: "ExpenseInformations",
                column: "PaymentType");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseInformations_VenderId",
                table: "ExpenseInformations",
                column: "VenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypes_CreatedBy",
                table: "PaymentTypes",
                column: "CreatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseDetailsInformations");

            migrationBuilder.DropTable(
                name: "ExpenseInformations");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.UpdateData(
                table: "AccountsInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 59, 28, 505, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "BloodGroupInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 59, 28, 452, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "ControlAccountInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 59, 28, 491, DateTimeKind.Local));

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
                table: "HeadAccountsInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 59, 28, 499, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "ProductInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 26, 13, 59, 28, 432, DateTimeKind.Local));

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
                table: "TransictionInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ForDate" },
                values: new object[] { new DateTime(2022, 2, 26, 13, 59, 28, 514, DateTimeKind.Local), new DateTime(2022, 2, 26, 13, 59, 28, 514, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TransictionInformations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ForDate" },
                values: new object[] { new DateTime(2022, 2, 26, 13, 59, 28, 514, DateTimeKind.Local), new DateTime(2022, 2, 26, 13, 59, 28, 514, DateTimeKind.Local) });

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
        }
    }
}
