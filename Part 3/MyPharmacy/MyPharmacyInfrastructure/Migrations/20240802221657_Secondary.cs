using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPharmacyInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Secondary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Pharmacies_LastPharmacyId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<double>(
                name: "clatti",
                table: "AspNetUsers",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "clongi",
                table: "AspNetUsers",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "distance",
                table: "AspNetUsers",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "latti",
                table: "AspNetUsers",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "longi",
                table: "AspNetUsers",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Pharmacies_LastPharmacyId",
                table: "AspNetUsers",
                column: "LastPharmacyId",
                principalTable: "Pharmacies",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Pharmacies_LastPharmacyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "clatti",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "clongi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "distance",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "latti",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "longi",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Pharmacies_LastPharmacyId",
                table: "AspNetUsers",
                column: "LastPharmacyId",
                principalTable: "Pharmacies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
