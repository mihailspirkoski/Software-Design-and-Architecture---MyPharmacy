using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyPharmacyInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedEntitiesAddLocationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "clatti",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "clongi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "distance",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "LastLocationId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "lastLocationId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    longitude = table.Column<double>(type: "double precision", nullable: false),
                    latitude = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LastLocationId",
                table: "AspNetUsers",
                column: "LastLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Locations_LastLocationId",
                table: "AspNetUsers",
                column: "LastLocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Locations_LastLocationId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LastLocationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastLocationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "lastLocationId",
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
        }
    }
}
