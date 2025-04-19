using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroceryManagement.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class addedNullableToOrdersCustomerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_tbl_Customers_tbl_CustomerId",
                table: "Orders_tbl");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Orders_tbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_tbl_Customers_tbl_CustomerId",
                table: "Orders_tbl",
                column: "CustomerId",
                principalTable: "Customers_tbl",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_tbl_Customers_tbl_CustomerId",
                table: "Orders_tbl");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Orders_tbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_tbl_Customers_tbl_CustomerId",
                table: "Orders_tbl",
                column: "CustomerId",
                principalTable: "Customers_tbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
