using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Challenge24.Data.Migrations
{
    public partial class _12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChallengeUser_Challenge_ChallengeId",
                table: "ChallengeUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Challenge",
                table: "Challenge");

            migrationBuilder.RenameTable(
                name: "Challenge",
                newName: "Challenges");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Challenges",
                table: "Challenges",
                column: "ChallengeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChallengeUser_Challenges_ChallengeId",
                table: "ChallengeUser",
                column: "ChallengeId",
                principalTable: "Challenges",
                principalColumn: "ChallengeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChallengeUser_Challenges_ChallengeId",
                table: "ChallengeUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Challenges",
                table: "Challenges");

            migrationBuilder.RenameTable(
                name: "Challenges",
                newName: "Challenge");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Challenge",
                table: "Challenge",
                column: "ChallengeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChallengeUser_Challenge_ChallengeId",
                table: "ChallengeUser",
                column: "ChallengeId",
                principalTable: "Challenge",
                principalColumn: "ChallengeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
