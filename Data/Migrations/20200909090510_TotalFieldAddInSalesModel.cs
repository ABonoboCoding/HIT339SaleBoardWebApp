using Microsoft.EntityFrameworkCore.Migrations;

namespace MLSaleBoard.Data.Migrations
{
    public partial class TotalFieldAddInSalesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Sales",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Sales");
        }
    }
}
