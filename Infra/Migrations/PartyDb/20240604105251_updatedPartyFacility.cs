using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations.PartyDb
{
    /// <inheritdoc />
    public partial class updatedPartyFacility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Facility",
                newName: "Facility",
                newSchema: "Party");

            migrationBuilder.AlterColumn<string>(
                name: "PartyId",
                schema: "Party",
                table: "PartyFacility",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacilityId",
                schema: "Party",
                table: "PartyFacility",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PartyFacility_PartyId_FacilityId",
                schema: "Party",
                table: "PartyFacility",
                columns: new[] { "PartyId", "FacilityId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_PartyFacility_PartyId_FacilityId",
                schema: "Party",
                table: "PartyFacility");

            migrationBuilder.DropColumn(
                name: "FacilityId",
                schema: "Party",
                table: "PartyFacility");

            migrationBuilder.RenameTable(
                name: "Facility",
                schema: "Party",
                newName: "Facility");

            migrationBuilder.AlterColumn<string>(
                name: "PartyId",
                schema: "Party",
                table: "PartyFacility",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
