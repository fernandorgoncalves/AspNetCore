using Microsoft.EntityFrameworkCore.Migrations;

namespace Cibergestion.Data.Migrations
{
    public partial class AlteraçãodeProjeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "codigo_fun",
                table: "funcionarios",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "codigo_fun",
                table: "funcionarios");
        }
    }
}
