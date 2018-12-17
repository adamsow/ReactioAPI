using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactioAPI.Core.Migrations
{
    public partial class AddedPLLocalizationToEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NamePL",
                table: "Substrate",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NamePL",
                table: "Reaction",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NamePL",
                table: "Product",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NamePL",
                table: "Substrate");

            migrationBuilder.DropColumn(
                name: "NamePL",
                table: "Reaction");

            migrationBuilder.DropColumn(
                name: "NamePL",
                table: "Product");
        }
    }
}
