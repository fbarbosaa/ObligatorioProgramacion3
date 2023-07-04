using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObligatorioProgramacion3.Migrations
{
    public partial class controlerpelicula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Peliculas",
                newName: "PeliculaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PeliculaId",
                table: "Peliculas",
                newName: "Id");
        }
    }
}
