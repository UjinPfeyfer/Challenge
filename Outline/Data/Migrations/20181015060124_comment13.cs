using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Challenge24.Data.Migrations
{
    public partial class comment13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Outlines_OutlineId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "OutlineId",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Outlines_OutlineId",
                table: "Comments",
                column: "OutlineId",
                principalTable: "Outlines",
                principalColumn: "OutlineId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Outlines_OutlineId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "OutlineId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Outlines_OutlineId",
                table: "Comments",
                column: "OutlineId",
                principalTable: "Outlines",
                principalColumn: "OutlineId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
