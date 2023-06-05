using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EticketsWebApp.Migrations
{
    public partial class RenameAllentitiesPKwithId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProducerId",
                table: "Producers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CinemaId",
                table: "Cinemas",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Producers",
                newName: "ProducerId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cinemas",
                newName: "CinemaId");
        }
    }
}
