using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPharmacyInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LastCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "latti",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "longi",
                table: "AspNetUsers");
        }
    }
}
