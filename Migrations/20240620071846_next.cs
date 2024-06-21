using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FAZ.Migrations
{
    /// <inheritdoc />
    public partial class next : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePlayed",
                table: "Matches",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "News",
                table: "Matches",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssistantReferee1Id",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "AssistantReferee2Id",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "News",
                table: "Matches");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DatePlayed",
                table: "Matches",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }
    }
}
