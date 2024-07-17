﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autotech.BusinessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Itemsupdate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "itemDetailsId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Items_itemDetailsId",
                table: "Items",
                column: "itemDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemDetails_itemDetailsId",
                table: "Items",
                column: "itemDetailsId",
                principalTable: "ItemDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemDetails_itemDetailsId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_itemDetailsId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "itemDetailsId",
                table: "Items");
        }
    }
}
