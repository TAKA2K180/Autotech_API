using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autotech.BusinessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Itemsupdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemsSold = table.Column<double>(type: "float", nullable: false),
                    Sales = table.Column<double>(type: "float", nullable: false),
                    OnHand = table.Column<double>(type: "float", nullable: false),
                    BataanRetail = table.Column<double>(type: "float", nullable: false),
                    BataanWholeSale = table.Column<double>(type: "float", nullable: false),
                    PampangaRetail = table.Column<double>(type: "float", nullable: false),
                    PampangaWholeSale = table.Column<double>(type: "float", nullable: false),
                    ZambalesRetail = table.Column<double>(type: "float", nullable: false),
                    ZambalesWholeSale = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDetails", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemDetails");
        }
    }
}
