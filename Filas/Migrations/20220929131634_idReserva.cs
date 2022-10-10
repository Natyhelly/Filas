using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filas.Migrations
{
    public partial class idReserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID_REVERSA",
                table: "Reservas",
                newName: "ID_RESERVA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID_RESERVA",
                table: "Reservas",
                newName: "ID_REVERSA");
        }
    }
}
