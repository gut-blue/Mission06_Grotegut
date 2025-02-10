﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mission6Assignment.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSecondaryCategoryName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondaryCategoryName",
                table: "Movies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecondaryCategoryName",
                table: "Movies",
                type: "TEXT",
                nullable: true);
        }
    }
}
