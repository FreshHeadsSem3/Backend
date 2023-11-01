using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreshHeadBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCategoryV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_DealCategories_DealCategoryID",
                table: "Deals");

            migrationBuilder.RenameColumn(
                name: "DealCategoryID",
                table: "Deals",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Deals_DealCategoryID",
                table: "Deals",
                newName: "IX_Deals_CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_DealCategories_CategoryID",
                table: "Deals",
                column: "CategoryID",
                principalTable: "DealCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_DealCategories_CategoryID",
                table: "Deals");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Deals",
                newName: "DealCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Deals_CategoryID",
                table: "Deals",
                newName: "IX_Deals_DealCategoryID");

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
