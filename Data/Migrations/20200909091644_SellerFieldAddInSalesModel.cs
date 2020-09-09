using Microsoft.EntityFrameworkCore.Migrations;

namespace MLSaleBoard.Data.Migrations
{
    public partial class SellerFieldAddInSalesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Seller",
                table: "Sales",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seller",
                table: "Sales");
        }
    }
}
