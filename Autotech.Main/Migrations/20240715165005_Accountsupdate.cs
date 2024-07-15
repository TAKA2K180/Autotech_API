using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autotech.Main.Migrations
{
    /// <inheritdoc />
    public partial class Accountsupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_BaseModel_Id",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_BaseModel_Id",
                table: "Products");

            migrationBuilder.DropTable(
                name: "BaseModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseModel", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_BaseModel_Id",
                table: "Accounts",
                column: "Id",
                principalTable: "BaseModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_BaseModel_Id",
                table: "Products",
                column: "Id",
                principalTable: "BaseModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
