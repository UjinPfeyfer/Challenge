using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Challenge24.Data.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Challenge",
                columns: table => new
                {
                    ChallengeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Condition = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FinishDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenge", x => x.ChallengeId);
                });

            migrationBuilder.CreateTable(
                name: "ChallengeUser",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    ChallengeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengeUser", x => new { x.UserId, x.ChallengeId });
                    table.ForeignKey(
                        name: "FK_ChallengeUser_Challenge_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenge",
                        principalColumn: "ChallengeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChallengeUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeUser_ChallengeId",
                table: "ChallengeUser",
                column: "ChallengeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChallengeUser");

            migrationBuilder.DropTable(
                name: "Challenge");
        }
    }
}
