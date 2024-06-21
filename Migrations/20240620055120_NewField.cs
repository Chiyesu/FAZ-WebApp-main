using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FAZ.Migrations
{
    /// <inheritdoc />
    public partial class NewField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DatePlayed",
                table: "MatchParticipation",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatePlayed",
                table: "MatchParticipation");
        }
    }
}
