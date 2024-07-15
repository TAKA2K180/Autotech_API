using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autotech.Main.Migrations
{
    /// <inheritdoc />
    public partial class Accountsupdate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountDetails_AccountDetailsId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountDetailsId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountDetailsId",
                table: "Accounts");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDetails_Accounts_Id",
                table: "AccountDetails",
                column: "Id",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountDetails_Accounts_Id",
                table: "AccountDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountDetailsId",
                table: "Accounts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountDetailsId",
                table: "Accounts",
                column: "AccountDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountDetails_AccountDetailsId",
                table: "Accounts",
                column: "AccountDetailsId",
                principalTable: "AccountDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
