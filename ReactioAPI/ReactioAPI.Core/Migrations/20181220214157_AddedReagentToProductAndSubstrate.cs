using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ReactioAPI.Core.Migrations
{
    public partial class AddedReagentToProductAndSubstrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Substrate_ReagentID",
                table: "Substrate",
                column: "ReagentID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ReagentID",
                table: "Product",
                column: "ReagentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Reagent_ReagentID",
                table: "Product",
                column: "ReagentID",
                principalTable: "Reagent",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Substrate_Reagent_ReagentID",
                table: "Substrate",
                column: "ReagentID",
                principalTable: "Reagent",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Reagent_ReagentID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Substrate_Reagent_ReagentID",
                table: "Substrate");

            migrationBuilder.DropIndex(
                name: "IX_Substrate_ReagentID",
                table: "Substrate");

            migrationBuilder.DropIndex(
                name: "IX_Product_ReagentID",
                table: "Product");
        }
    }
}
