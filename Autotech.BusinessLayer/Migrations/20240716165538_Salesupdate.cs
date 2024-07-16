using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autotech.BusinessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Salesupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateSold = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Agent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountPercent = table.Column<double>(type: "float", nullable: false),
                    DiscountPeso = table.Column<double>(type: "float", nullable: false),
                    Tax = table.Column<double>(type: "float", nullable: false),
                    TotalSales = table.Column<double>(type: "float", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Terms = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemainingBalance = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalLiters = table.Column<double>(type: "float", nullable: false),
                    Cluster = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");
        }
    }
}
