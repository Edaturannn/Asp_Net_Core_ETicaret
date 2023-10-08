using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class CreateNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GenderTables",
                columns: table => new
                {
                    GenderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenderImages = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderTables", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "MessageTables",
                columns: table => new
                {
                    MessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAdminName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTables", x => x.MessageID);
                });

            migrationBuilder.CreateTable(
                name: "UserAdminTables",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Locked = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdminTables", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTables",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CategoryImages = table.Column<string>(type: "nvarchar(310)", maxLength: 310, nullable: false),
                    CategoryCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryStok = table.Column<int>(type: "int", nullable: true),
                    GenderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTables", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_CategoryTables_GenderTables_GenderID",
                        column: x => x.GenderID,
                        principalTable: "GenderTables",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTables",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    ProductTitle = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ProductImages = table.Column<string>(type: "nvarchar(310)", maxLength: 310, nullable: false),
                    ProductPrice = table.Column<int>(type: "int", nullable: false),
                    ProductStok = table.Column<int>(type: "int", nullable: false),
                    ProductCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTables", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_ProductTables_CategoryTables_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "CategoryTables",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentTables",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentMessage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CommentCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserAdminTableID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentTables", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_CommentTables_ProductTables_ProductID",
                        column: x => x.ProductID,
                        principalTable: "ProductTables",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentTables_UserAdminTables_UserAdminTableID",
                        column: x => x.UserAdminTableID,
                        principalTable: "UserAdminTables",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OrderTables",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTables", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_OrderTables_ProductTables_ProductID",
                        column: x => x.ProductID,
                        principalTable: "ProductTables",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTables_GenderID",
                table: "CategoryTables",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentTables_ProductID",
                table: "CommentTables",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentTables_UserAdminTableID",
                table: "CommentTables",
                column: "UserAdminTableID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTables_ProductID",
                table: "OrderTables",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTables_CategoryID",
                table: "ProductTables",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentTables");

            migrationBuilder.DropTable(
                name: "MessageTables");

            migrationBuilder.DropTable(
                name: "OrderTables");

            migrationBuilder.DropTable(
                name: "UserAdminTables");

            migrationBuilder.DropTable(
                name: "ProductTables");

            migrationBuilder.DropTable(
                name: "CategoryTables");

            migrationBuilder.DropTable(
                name: "GenderTables");
        }
    }
}
