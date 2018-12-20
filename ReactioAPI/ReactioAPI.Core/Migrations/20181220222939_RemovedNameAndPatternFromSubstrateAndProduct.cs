using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactioAPI.Core.Migrations
{
    public partial class RemovedNameAndPatternFromSubstrateAndProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Substrate");

            migrationBuilder.DropColumn(
                name: "NamePL",
                table: "Substrate");

            migrationBuilder.DropColumn(
                name: "Pattern",
                table: "Substrate");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "NamePL",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Pattern",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Substrate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamePL",
                table: "Substrate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pattern",
                table: "Substrate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NamePL",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pattern",
                table: "Product",
                nullable: true);
        }
    }
}
