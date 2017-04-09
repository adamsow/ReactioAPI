using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactioAPI.Core.Migrations
{
    public partial class SubstratesAndProducts3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Reaction");

            migrationBuilder.RenameColumn(
                name: "SubstrateId",
                table: "Reaction",
                newName: "MyProperty");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Reaction",
                newName: "SubstrateId");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Reaction",
                nullable: false,
                defaultValue: 0);
        }
    }
}
