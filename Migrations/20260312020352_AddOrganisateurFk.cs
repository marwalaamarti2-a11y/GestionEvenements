using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionEvenements.Migrations
{
    /// <inheritdoc />
    public partial class AddOrganisateurFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganisateurId",
                table: "Evenements",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Evenements_OrganisateurId",
                table: "Evenements",
                column: "OrganisateurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evenements_Organisateurs_OrganisateurId",
                table: "Evenements",
                column: "OrganisateurId",
                principalTable: "Organisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evenements_Organisateurs_OrganisateurId",
                table: "Evenements");

            migrationBuilder.DropIndex(
                name: "IX_Evenements_OrganisateurId",
                table: "Evenements");

            migrationBuilder.DropColumn(
                name: "OrganisateurId",
                table: "Evenements");
        }
    }
}
