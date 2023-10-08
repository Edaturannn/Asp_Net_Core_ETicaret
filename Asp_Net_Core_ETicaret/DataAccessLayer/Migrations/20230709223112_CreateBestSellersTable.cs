using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class CreateBestSellersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BestSellersTables",
                columns: table => new
                {
                    BestSellersID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BestSellersName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BestSellersTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BestSellersDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BestSellersImages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BestSellersPrice = table.Column<int>(type: "int", nullable: false),
                    BestSellersCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BestSellersTables", x => x.BestSellersID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BestSellersTables");
        }
    }
}
