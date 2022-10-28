using Microsoft.EntityFrameworkCore.Migrations;

namespace RHWEBAPP2.Data.Migrations
{
    public partial class RemoveNivel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nivel",
                table: "Capacitaciones");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nivel",
                table: "Capacitaciones",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
