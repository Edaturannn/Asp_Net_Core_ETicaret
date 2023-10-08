using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class NewMig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameSurname",
                table: "OrderTables");

            migrationBuilder.AddColumn<Guid>(
                name: "ID",
                table: "OrderTables",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserAdminTableID",
                table: "OrderTables",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderTables_UserAdminTableID",
                table: "OrderTables",
                column: "UserAdminTableID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTables_UserAdminTables_UserAdminTableID",
                table: "OrderTables",
                column: "UserAdminTableID",
                principalTable: "UserAdminTables",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderTables_UserAdminTables_UserAdminTableID",
                table: "OrderTables");

            migrationBuilder.DropIndex(
                name: "IX_OrderTables_UserAdminTableID",
                table: "OrderTables");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "OrderTables");

            migrationBuilder.DropColumn(
                name: "UserAdminTableID",
                table: "OrderTables");

            migrationBuilder.AddColumn<string>(
                name: "NameSurname",
                table: "OrderTables",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
