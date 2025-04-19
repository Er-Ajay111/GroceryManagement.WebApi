using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroceryManagement.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class deletdCusomerIdFromOrderItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_tbl_Category_tbl_CategoryId",
                table: "OrderItems_tbl");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_tbl_CategoryId",
                table: "OrderItems_tbl");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "OrderItems_tbl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "OrderItems_tbl",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_tbl_CategoryId",
                table: "OrderItems_tbl",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_tbl_Category_tbl_CategoryId",
                table: "OrderItems_tbl",
                column: "CategoryId",
                principalTable: "Category_tbl",
                principalColumn: "Id");
        }
    }
}
