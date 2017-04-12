using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactioAPI.Core.Migrations
{
    public partial class factorAndType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Factor",
                table: "Reaction");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Reaction");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Factor",
                table: "Reaction",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Reaction",
                nullable: true);
        }
    }
}
