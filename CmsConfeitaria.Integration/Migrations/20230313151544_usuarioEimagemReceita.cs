using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CmsConfeitaria.Integration.Migrations
{
    /// <inheritdoc />
    public partial class usuarioEimagemReceita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ImagemReceita_ReceitaId",
                table: "ImagemReceita");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagemReceita_ReceitaId",
                table: "ImagemReceita",
                column: "ReceitaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_ImagemReceita_ReceitaId",
                table: "ImagemReceita");

            migrationBuilder.CreateIndex(
                name: "IX_ImagemReceita_ReceitaId",
                table: "ImagemReceita",
                column: "ReceitaId");
        }
    }
}
