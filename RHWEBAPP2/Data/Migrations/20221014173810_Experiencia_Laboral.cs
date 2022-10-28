using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RHWEBAPP2.Data.Migrations
{
    public partial class Experiencia_Laboral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Experiencia_Laboral",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Puesto_Ocupado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha_Desde = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Hasta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiencia_Laboral", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Experiencia_Laboral");
        }
    }
}
