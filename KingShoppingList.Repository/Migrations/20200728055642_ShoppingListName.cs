using Microsoft.EntityFrameworkCore.Migrations;

namespace KingShoppingList.Repository.Migrations
{
    public partial class ShoppingListName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ShoppingLists",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ShoppingLists");
        }
    }
}
