using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CmsConfeitaria.Integration.Migrations
{
    /// <inheritdoc />
    public partial class TemplateAndRotinaConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "RotinaDisparos",
                newName: "Intervalo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Intervalo",
                table: "RotinaDisparos",
                newName: "Date");
        }
    }
}
