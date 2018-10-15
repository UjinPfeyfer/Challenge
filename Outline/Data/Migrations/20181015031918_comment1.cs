using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Challenge24.Data.Migrations
{
    public partial class comment1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Outlines_OutlineId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_OutlineUser_OutlineUserUserId_OutlineUserOutlineId",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_OutlineUserUserId_OutlineUserOutlineId",
                table: "Comments",
                newName: "IX_Comments_OutlineUserUserId_OutlineUserOutlineId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_OutlineId",
                table: "Comments",
                newName: "IX_Comments_OutlineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Outlines_OutlineId",
                table: "Comments",
                column: "OutlineId",
                principalTable: "Outlines",
                principalColumn: "OutlineId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_OutlineUser_OutlineUserUserId_OutlineUserOutlineId",
                table: "Comments",
                columns: new[] { "OutlineUserUserId", "OutlineUserOutlineId" },
                principalTable: "OutlineUser",
                principalColumns: new[] { "UserId", "OutlineId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Outlines_OutlineId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_OutlineUser_OutlineUserUserId_OutlineUserOutlineId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_OutlineUserUserId_OutlineUserOutlineId",
                table: "Comment",
                newName: "IX_Comment_OutlineUserUserId_OutlineUserOutlineId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_OutlineId",
                table: "Comment",
                newName: "IX_Comment_OutlineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Outlines_OutlineId",
                table: "Comment",
                column: "OutlineId",
                principalTable: "Outlines",
                principalColumn: "OutlineId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_OutlineUser_OutlineUserUserId_OutlineUserOutlineId",
                table: "Comment",
                columns: new[] { "OutlineUserUserId", "OutlineUserOutlineId" },
                principalTable: "OutlineUser",
                principalColumns: new[] { "UserId", "OutlineId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
