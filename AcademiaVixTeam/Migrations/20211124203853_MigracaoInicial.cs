using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademiaVixTeam.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PessoalModel",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantidadeFilhos = table.Column<int>(type: "int", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoalModel", x => x.Codigo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PessoalModel");
        }
    }
}
