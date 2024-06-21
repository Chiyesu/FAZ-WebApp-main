using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FAZ.Migrations
{
    /// <inheritdoc />
    public partial class updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlayerName",
                table: "MatchParticipation",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePlayed",
                table: "Matches",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<int>(
                name: "AssistantReferee1Id",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AssistantReferee2Id",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerName",
                table: "MatchParticipation");

            migrationBuilder.DropColumn(
                name: "AssistantReferee1Id",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "AssistantReferee2Id",
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
