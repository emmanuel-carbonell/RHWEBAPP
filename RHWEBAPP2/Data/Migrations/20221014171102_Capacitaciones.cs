using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RHWEBAPP2.Data.Migrations
{
    public partial class Capacitaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Capacitaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nivel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha_Desde = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Hasta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Institucion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capacitaciones", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Capacitaciones");
        }
    }
}
