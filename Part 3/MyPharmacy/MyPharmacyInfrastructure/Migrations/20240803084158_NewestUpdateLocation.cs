using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPharmacyInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewestUpdateLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "distance",
                table: "Locations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "distance",
                table: "Locations");
        }
    }
}
