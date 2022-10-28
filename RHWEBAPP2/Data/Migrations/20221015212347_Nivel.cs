using Microsoft.EntityFrameworkCore.Migrations;

namespace RHWEBAPP2.Data.Migrations
{
    public partial class Nivel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Nivel",
                table: "Capacitaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nivel",
                table: "Capacitaciones");
        }
    }
}
