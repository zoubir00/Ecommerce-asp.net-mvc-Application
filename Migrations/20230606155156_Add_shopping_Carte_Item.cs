using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EticketsWebApp.Migrations
{
    public partial class Add_shopping_Carte_Item : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCarteItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MyPropertyId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ShoppingCarteId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarteItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarteItems_Movies_MyPropertyId",
                        column: x => x.MyPropertyId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarteItems_MyPropertyId",
                table: "ShoppingCarteItems",
                column: "MyPropertyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCarteItems");
        }
    }
}
