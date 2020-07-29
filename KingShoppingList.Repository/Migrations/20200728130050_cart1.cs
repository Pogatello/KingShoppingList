using Microsoft.EntityFrameworkCore.Migrations;

namespace KingShoppingList.Repository.Migrations
{
    public partial class cart1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "ListItems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListItems_ShoppingCartId",
                table: "ListItems",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListItems_ShoppingCart_ShoppingCartId",
                table: "ListItems",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListItems_ShoppingCart_ShoppingCartId",
                table: "ListItems");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_ListItems_ShoppingCartId",
                table: "ListItems");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "ListItems");
        }
    }
}
