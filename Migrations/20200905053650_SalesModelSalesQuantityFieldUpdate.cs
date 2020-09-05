using Microsoft.EntityFrameworkCore.Migrations;

namespace MinxuanLinSaleBoardSite.Migrations
{
    public partial class SalesModelSalesQuantityFieldUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemQuantity",
                table: "Sales");

            migrationBuilder.AddColumn<int>(
                name: "SaleQuantity",
                table: "Sales",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaleQuantity",
                table: "Sales");

            migrationBuilder.AddColumn<int>(
                name: "ItemQuantity",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
