using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactioAPI.Core.Migrations
{
    public partial class factorAndType4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Factor",
                table: "Reaction",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Reaction",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Factor",
                table: "Reaction");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Reaction");
        }
    }
}
