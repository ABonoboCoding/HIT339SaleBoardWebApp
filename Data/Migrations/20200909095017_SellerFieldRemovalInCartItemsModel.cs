using Microsoft.EntityFrameworkCore.Migrations;

namespace MLSaleBoard.Data.Migrations
{
    public partial class SellerFieldRemovalInCartItemsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seller",
                table: "CartItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Seller",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
