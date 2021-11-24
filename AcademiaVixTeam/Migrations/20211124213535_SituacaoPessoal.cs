using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademiaVixTeam.Migrations
{
    public partial class SituacaoPessoal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Situacao",
                table: "PessoalModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Situacao",
                table: "PessoalModel");
        }
    }
}
