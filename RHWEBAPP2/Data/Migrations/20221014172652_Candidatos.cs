using Microsoft.EntityFrameworkCore.Migrations;

namespace RHWEBAPP2.Data.Migrations
{
    public partial class Candidatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Puesto_Al_Que_Aspira = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salario_Al_Que_Aspira = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Principales_Competencias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Principales_Capacitaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experiencia_Laboral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recomendado_Por = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidatos");
        }
    }
}
