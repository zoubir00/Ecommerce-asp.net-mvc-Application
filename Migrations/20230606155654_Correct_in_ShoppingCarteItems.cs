using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EticketsWebApp.Migrations
{
    public partial class Correct_in_ShoppingCarteItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarteItems_Movies_MyPropertyId",
                table: "ShoppingCarteItems");

            migrationBuilder.RenameColumn(
                name: "MyPropertyId",
                table: "ShoppingCarteItems",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarteItems_MyPropertyId",
                table: "ShoppingCarteItems",
                newName: "IX_ShoppingCarteItems_MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarteItems_Movies_MovieId",
                table: "ShoppingCarteItems",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarteItems_Movies_MovieId",
                table: "ShoppingCarteItems");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "ShoppingCarteItems",
                newName: "MyPropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarteItems_MovieId",
                table: "ShoppingCarteItems",
                newName: "IX_ShoppingCarteItems_MyPropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarteItems_Movies_MyPropertyId",
                table: "ShoppingCarteItems",
                column: "MyPropertyId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
