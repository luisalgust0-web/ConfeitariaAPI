using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CmsConfeitaria.Integration.Migrations
{
    /// <inheritdoc />
    public partial class compraIngredienteRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RotinaDisparos");

            migrationBuilder.DropTable(
                name: "TemplateEmails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RotinaDisparos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Intervalo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoIntervalo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RotinaDisparos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TemplateEmails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateEmails", x => x.Id);
                });
        }
    }
}
