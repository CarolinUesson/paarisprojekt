using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations.PartyDb
{
    /// <inheritdoc />
    public partial class StringsToInts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PartyId",
                schema: "Party",
                table: "PartyFacility",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "FacilityId",
                schema: "Party",
                table: "PartyFacility",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PartyId",
                schema: "Party",
                table: "PartyFacility",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FacilityId",
                schema: "Party",
                table: "PartyFacility",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
