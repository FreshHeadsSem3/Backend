using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreshHeadBackend.Migrations
{
    /// <inheritdoc />
    public partial class KVK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
