using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactioAPI.Core.Migrations
{
    public partial class AddedReagentIdToProductAndSubstrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReagentID",
                table: "Product",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReagentID",
                table: "Substrate",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReagentID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ReagentID",
                table: "Substrate");
        }
    }
}
