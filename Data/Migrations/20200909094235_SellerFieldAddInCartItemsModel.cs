using Microsoft.EntityFrameworkCore.Migrations;

namespace MLSaleBoard.Data.Migrations
{
    public partial class SellerFieldAddInCartItemsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Seller",
                table: "CartItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seller",
                table: "CartItems");
        }
    }
}
