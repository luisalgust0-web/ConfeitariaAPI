using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CmsConfeitaria.Integration.Migrations
{
    /// <inheritdoc />
    public partial class compraIngredienteDataCompra2DataCadastro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataCompra",
                table: "Compra",
                newName: "DataCadastro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataCadastro",
                table: "Compra",
                newName: "DataCompra");
        }
    }
}
