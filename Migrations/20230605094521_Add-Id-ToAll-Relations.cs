using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EticketsWebApp.Migrations
{
    public partial class AddIdToAllRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Movies_Actors_Actorid",
                table: "Actors_Movies");

            migrationBuilder.RenameColumn(
                name: "Actorid",
                table: "Actors_Movies",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Movies_Actors_Id",
                table: "Actors_Movies",
                column: "Id",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Movies_Actors_Id",
                table: "Actors_Movies");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Actors_Movies",
                newName: "Actorid");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Movies_Actors_Actorid",
                table: "Actors_Movies",
                column: "Actorid",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
