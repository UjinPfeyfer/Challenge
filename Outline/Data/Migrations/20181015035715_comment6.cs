using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Challenge24.Data.Migrations
{
    public partial class comment6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_OutlineUser_OutlineUserUserId_OutlineUserOutlineId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_OutlineUserUserId_OutlineUserOutlineId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "OutlineUserOutlineId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "OutlineUserUserId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "OutlineUser",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "OutlineUser");

            migrationBuilder.AddColumn<int>(
                name: "OutlineUserOutlineId",
                table: "Comments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OutlineUserUserId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_OutlineUserUserId_OutlineUserOutlineId",
                table: "Comments",
                columns: new[] { "OutlineUserUserId", "OutlineUserOutlineId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_OutlineUser_OutlineUserUserId_OutlineUserOutlineId",
                table: "Comments",
                columns: new[] { "OutlineUserUserId", "OutlineUserOutlineId" },
                principalTable: "OutlineUser",
                principalColumns: new[] { "UserId", "OutlineId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
