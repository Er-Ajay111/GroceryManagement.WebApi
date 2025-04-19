using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroceryManagement.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class newDatabaseAndTablesCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers_tbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_tbl_Category_tbl_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category_tbl",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_tbl_Customers_tbl_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DealerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CostPerQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_tbl_Category_tbl_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category_tbl",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Stocks_tbl_Items_tbl_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items_tbl",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CostPerQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems_tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_tbl_Category_tbl_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category_tbl",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItems_tbl_Items_tbl_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items_tbl",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItems_tbl_Orders_tbl_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders_tbl",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_tbl_CategoryId",
                table: "Items_tbl",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_tbl_CategoryId",
                table: "OrderItems_tbl",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_tbl_ItemId",
                table: "OrderItems_tbl",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_tbl_OrderId",
                table: "OrderItems_tbl",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_tbl_CustomerId",
                table: "Orders_tbl",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_tbl_CategoryId",
                table: "Stocks_tbl",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_tbl_ItemId",
                table: "Stocks_tbl",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems_tbl");

            migrationBuilder.DropTable(
                name: "Stocks_tbl");

            migrationBuilder.DropTable(
                name: "Orders_tbl");

            migrationBuilder.DropTable(
                name: "Items_tbl");

            migrationBuilder.DropTable(
                name: "Customers_tbl");

            migrationBuilder.DropTable(
                name: "Category_tbl");
        }
    }
}
