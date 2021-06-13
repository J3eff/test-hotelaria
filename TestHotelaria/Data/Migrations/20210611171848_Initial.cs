using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestHotelaria.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hoteis",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    ResumoHotel = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    Avaliacao = table.Column<int>(nullable: false),
                    Endereco = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Comodidade = table.Column<string>(type: "varchar(300)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoteis", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hoteis");
        }
    }
}
