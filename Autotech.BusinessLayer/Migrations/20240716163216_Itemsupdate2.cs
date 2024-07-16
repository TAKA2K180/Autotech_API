using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autotech.BusinessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Itemsupdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RetailPrice",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "WholesalePrice",
                table: "Locations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "RetailPrice",
                table: "Locations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "WholesalePrice",
                table: "Locations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
