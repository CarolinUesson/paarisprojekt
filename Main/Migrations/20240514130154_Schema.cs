using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Main.Migrations
{
    /// <inheritdoc />
    public partial class Schema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Dep");

            migrationBuilder.RenameTable(
                name: "ProductFeature",
                newName: "ProductFeature",
                newSchema: "Dep");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Product",
                newSchema: "Dep");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ProductFeature",
                schema: "Dep",
                newName: "ProductFeature");

            migrationBuilder.RenameTable(
                name: "Product",
                schema: "Dep",
                newName: "Product");
        }
    }
}
