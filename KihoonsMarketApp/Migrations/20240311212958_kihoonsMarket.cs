using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KihoonMarketApp.Migrations
{
    /// <inheritdoc />
    public partial class kihoonsMarket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceOrState = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ZipOrPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTerms",
                columns: table => new
                {
                    PaymentTermsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTerms", x => x.PaymentTermsId);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentTotal = table.Column<double>(type: "float", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentTermsId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_PaymentTerms_PaymentTermsId",
                        column: x => x.PaymentTermsId,
                        principalTable: "PaymentTerms",
                        principalColumn: "PaymentTermsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLineItems",
                columns: table => new
                {
                    InvoiceLineItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLineItems", x => x.InvoiceLineItemId);
                    table.ForeignKey(
                        name: "FK_InvoiceLineItems_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId");
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address1", "Address2", "City", "ContactEmail", "ContactFirstName", "ContactLastName", "IsDeleted", "Name", "Phone", "ProvinceOrState", "ZipOrPostalCode" },
                values: new object[,]
                {
                    { 1, "549 Bluebeech BLVD", null, "Waterloo", "1@gmail.comm", "kihoon", "kim", false, "AKihoon", "000-000-0000", "CA", "N2V2TR" },
                    { 2, "649 Bluebeech BLVD", null, "Toronto", "2@gmail.comm", "jihoon", "lim", false, "DKihoon", "111-000-0000", "CA", "N2V2T2" },
                    { 3, "59 Bluebeech BLVD", null, "Cambridge", "3@gmail.comm", "FFFoon", "Smith", false, "EKihoon", "000-000-2222", "CA", "B2V2TR" },
                    { 4, "366 Bluebeech BLVD", null, "Waterloo", "4@gmail.comm", "stefan", "Siwert", false, "HKihoon", "444-000-0000", "CA", "N2V2TR" },
                    { 5, "236 BlNuebeech BLVD", null, "Waterloo", "5@gmail.comm", "Noah", "Lee", false, "NKihoon", "555-555-5555", "CA", "N2V2TR" },
                    { 6, "7 Bluebeech BLVD", null, "Seoul", "6@gmail.comm", "jimyung", "jeong", false, "YKihoon", "666-666-7777", "KR", "N2V2SR" },
                    { 7, "123 Bluebeech BLVD", null, "Kitchener", "7@gmail.comm", "kihoon", "kim", false, "JKihoon", "898-000-1254", "CA", "M2V2TR" },
                    { 8, "275 Bluebeech BLVD", null, "Waterloo", "8@gmail.comm", "kurt", "park", false, "LKihoon", "888-000-0120", "CA", "N2V2TR" }
                });

            migrationBuilder.InsertData(
                table: "PaymentTerms",
                columns: new[] { "PaymentTermsId", "Description", "DueDays" },
                values: new object[,]
                {
                    { 1, "Net due 10 days", 10 },
                    { 2, "Net due 20 days", 20 },
                    { 3, "Net due 30 days", 30 },
                    { 4, "Net due 60 days", 60 },
                    { 5, "Net due 90 days", 90 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "CustomerId", "InvoiceDate", "PaymentDate", "PaymentTermsId", "PaymentTotal" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0.0 },
                    { 2, 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0.0 },
                    { 3, 2, new DateTime(2022, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0.0 },
                    { 4, 2, new DateTime(2022, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 0.0 },
                    { 5, 3, new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0.0 },
                    { 6, 3, new DateTime(2022, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 0.0 },
                    { 7, 4, new DateTime(2022, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0.0 },
                    { 8, 4, new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 0.0 },
                    { 9, 5, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0.0 },
                    { 10, 6, new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0.0 },
                    { 11, 7, new DateTime(2022, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 0.0 },
                    { 12, 8, new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "InvoiceLineItems",
                columns: new[] { "InvoiceLineItemId", "Amount", "Description", "InvoiceId" },
                values: new object[,]
                {
                    { 1, 70.989999999999995, "Kimchi", 1 },
                    { 2, 10.5, "Normal Gimbab", 1 },
                    { 3, 12.5, "Bulgogi Gimbab", 2 },
                    { 4, 11.5, "Vegi Gimbab", 2 },
                    { 5, 15.5, "Red Chicken", 3 },
                    { 6, 16.899999999999999, "White Chicken", 3 },
                    { 7, 17.5, "Honey Chicken", 4 },
                    { 8, 20.5, "Tuna Sushi", 4 },
                    { 9, 18.5, "Salmon Sushi", 5 },
                    { 10, 40.5, "Sushi Set", 5 },
                    { 11, 22.899999999999999, "Ramen", 6 },
                    { 12, 19.5, "Kimchi Soup", 6 },
                    { 13, 18.5, "Soybean Soup", 7 },
                    { 14, 6.5, "Milkis", 8 },
                    { 15, 15.5, "Bibimbab", 9 },
                    { 16, 16.899999999999999, "Vegi Bibimbab", 9 },
                    { 17, 11.5, "Mandu(10pc)", 10 },
                    { 18, 9.5, "Bulgogi Bao", 10 },
                    { 19, 8.5, "YangYum Bao", 11 },
                    { 20, 20.5, "Bulgogi LunchBox", 11 },
                    { 21, 26.5, "Pork Belly", 12 },
                    { 22, 35.5, "Top Sironin", 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLineItems_InvoiceId",
                table: "InvoiceLineItems",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PaymentTermsId",
                table: "Invoices",
                column: "PaymentTermsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceLineItems");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "PaymentTerms");
        }
    }
}
