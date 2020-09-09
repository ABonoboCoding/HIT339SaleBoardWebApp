using Microsoft.EntityFrameworkCore.Migrations;

namespace MLSaleBoard.Data.Migrations
{
    public partial class RemovalOfCartIdFieldFromCartItemsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartId",
                table: "CartItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
