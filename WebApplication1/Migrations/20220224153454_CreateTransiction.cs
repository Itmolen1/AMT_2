using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class CreateTransiction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransictionInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<int>(nullable: false),
                    Dr = table.Column<float>(nullable: true),
                    Cr = table.Column<float>(nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ForDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransictionInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransictionInformations_AccountsInformations_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AccountsInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TransictionInformations_UserInformations_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "UserInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });
            
            migrationBuilder.UpdateData(
                table: "BloodGroupInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 19, 34, 53, 538, DateTimeKind.Local));
            
            migrationBuilder.UpdateData(
                table: "CustomerInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 19, 34, 53, 535, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DepartmentInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 19, 34, 53, 519, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DesignationInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 19, 34, 53, 526, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "EmployeeInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateofBirth", "DrivingLicienceExpiry", "HireDate", "IdCardExpiry", "PassportExpiry", "VisaExpiry" },
                values: new object[] { new DateTime(2022, 2, 24, 19, 34, 53, 542, DateTimeKind.Local), new DateTime(2022, 2, 24, 19, 34, 53, 542, DateTimeKind.Local), new DateTime(2022, 2, 24, 19, 34, 53, 543, DateTimeKind.Local), new DateTime(2022, 2, 24, 19, 34, 53, 542, DateTimeKind.Local), new DateTime(2022, 2, 24, 19, 34, 53, 542, DateTimeKind.Local), new DateTime(2022, 2, 24, 19, 34, 53, 543, DateTimeKind.Local), new DateTime(2022, 2, 24, 19, 34, 53, 543, DateTimeKind.Local) });
            
            migrationBuilder.UpdateData(
                table: "ProductInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 19, 34, 53, 531, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrackUpdateInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 19, 34, 53, 544, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "TransictionInformations",
                columns: new[] { "Id", "AccountId", "Cr", "CreatedBy", "CreatedDate", "Description", "Dr", "ForDate", "IsActive" },
                values: new object[,]
                {
                    { 1, 2, 0f, 1, new DateTime(2022, 2, 24, 19, 34, 53, 556, DateTimeKind.Local), "Owner invest as a cash", 5000f, new DateTime(2022, 2, 24, 19, 34, 53, 556, DateTimeKind.Local), true },
                    { 2, 1020, 5000f, 1, new DateTime(2022, 2, 24, 19, 34, 53, 556, DateTimeKind.Local), "Owner invest as a cash", 0f, new DateTime(2022, 2, 24, 19, 34, 53, 556, DateTimeKind.Local), true }
                });

            migrationBuilder.UpdateData(
                table: "UnitInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 19, 34, 53, 528, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 19, 34, 53, 519, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VehicleInformation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "InsuranceExpiry", "MulkiyaExpiry" },
                values: new object[] { new DateTime(2022, 2, 24, 19, 34, 53, 526, DateTimeKind.Local), new DateTime(2022, 2, 24, 19, 34, 53, 526, DateTimeKind.Local), new DateTime(2022, 2, 24, 19, 34, 53, 526, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "VehicleTypeInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 19, 34, 53, 538, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VenderInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 19, 34, 53, 538, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_TransictionInformations_AccountId",
                table: "TransictionInformations",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TransictionInformations_CreatedBy",
                table: "TransictionInformations",
                column: "CreatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransictionInformations");
            
            migrationBuilder.UpdateData(
                table: "BloodGroupInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 12, 6, 30, 266, DateTimeKind.Local));
            
            migrationBuilder.UpdateData(
                table: "CustomerInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 12, 6, 30, 263, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DepartmentInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 12, 6, 30, 236, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "DesignationInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 12, 6, 30, 250, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "EmployeeInformations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateofBirth", "DrivingLicienceExpiry", "HireDate", "IdCardExpiry", "PassportExpiry", "VisaExpiry" },
                values: new object[] { new DateTime(2022, 2, 24, 12, 6, 30, 271, DateTimeKind.Local), new DateTime(2022, 2, 24, 12, 6, 30, 271, DateTimeKind.Local), new DateTime(2022, 2, 24, 12, 6, 30, 271, DateTimeKind.Local), new DateTime(2022, 2, 24, 12, 6, 30, 271, DateTimeKind.Local), new DateTime(2022, 2, 24, 12, 6, 30, 271, DateTimeKind.Local), new DateTime(2022, 2, 24, 12, 6, 30, 271, DateTimeKind.Local), new DateTime(2022, 2, 24, 12, 6, 30, 271, DateTimeKind.Local) });
            
            migrationBuilder.UpdateData(
                table: "ProductInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 12, 6, 30, 256, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrackUpdateInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 12, 6, 30, 274, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UnitInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 12, 6, 30, 253, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 12, 6, 30, 235, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VehicleInformation",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "InsuranceExpiry", "MulkiyaExpiry" },
                values: new object[] { new DateTime(2022, 2, 24, 12, 6, 30, 250, DateTimeKind.Local), new DateTime(2022, 2, 24, 12, 6, 30, 250, DateTimeKind.Local), new DateTime(2022, 2, 24, 12, 6, 30, 250, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "VehicleTypeInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 12, 6, 30, 266, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "VenderInformations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 24, 12, 6, 30, 265, DateTimeKind.Local));
        }
    }
}
