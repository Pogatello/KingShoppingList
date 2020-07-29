using Microsoft.EntityFrameworkCore.Migrations;

namespace KingShoppingList.Repository.Migrations
{
    public partial class cart3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InCart",
                table: "ListItems",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InCart",
                table: "ListItems");
        }
    }
}
