using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreshHeadBackend.Migrations
{
    /// <inheritdoc />
    public partial class CompanyPropertiesChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_DealCategories_DealCategoryID",
                table: "Deals");

            migrationBuilder.DropTable(
                name: "DealCategories");

            migrationBuilder.DropIndex(
                name: "IX_Deals_DealCategoryID",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "DealCategoryID",
                table: "Deals");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Companies",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "KVK",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KVK",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Companies",
                newName: "Name");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryID",
                table: "Deals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DealCategoryID",
                table: "Deals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "DealCategories",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealCategories", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deals_DealCategoryID",
                table: "Deals",
                column: "DealCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_DealCategories_DealCategoryID",
                table: "Deals",
                column: "DealCategoryID",
                principalTable: "DealCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
