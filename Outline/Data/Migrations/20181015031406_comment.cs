using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Challenge24.Data.Migrations
{
    public partial class comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OutlineId",
                table: "Comment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_OutlineId",
                table: "Comment",
                column: "OutlineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Outlines_OutlineId",
                table: "Comment",
                column: "OutlineId",
                principalTable: "Outlines",
                principalColumn: "OutlineId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Outlines_OutlineId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_OutlineId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "OutlineId",
                table: "Comment");
        }
    }
}
