using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreshHeadBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDeal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ActiveTill",
                table: "Deals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Claimed",
                table: "Deals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Deals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaxParticipents",
                table: "Deals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveTill",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "Claimed",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "MaxParticipents",
                table: "Deals");
        }
    }
}
