using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreshHeadBackend.Migrations
{
    /// <inheritdoc />
    public partial class CompanyTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Companies",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Companies",
                newName: "Name");
        }
    }
}
