using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Challenge24.Data.Migrations
{
    public partial class OutLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyClass");

            migrationBuilder.DropTable(
                name: "ChallengeUser");

            migrationBuilder.DropTable(
                name: "Challenges");

            migrationBuilder.CreateTable(
                name: "Outlines",
                columns: table => new
                {
                    OutlineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreaterId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outlines", x => x.OutlineId);
                });

            migrationBuilder.CreateTable(
                name: "OutlineUser",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    OutlineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutlineUser", x => new { x.UserId, x.OutlineId });
                    table.ForeignKey(
                        name: "FK_OutlineUser_Outlines_OutlineId",
                        column: x => x.OutlineId,
                        principalTable: "Outlines",
                        principalColumn: "OutlineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutlineUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreaterId = table.Column<int>(nullable: false),
                    OutlineUserOutlineId = table.Column<int>(nullable: true),
                    OutlineUserUserId = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_OutlineUser_OutlineUserUserId_OutlineUserOutlineId",
                        columns: x => new { x.OutlineUserUserId, x.OutlineUserOutlineId },
                        principalTable: "OutlineUser",
                        principalColumns: new[] { "UserId", "OutlineId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_OutlineUserUserId_OutlineUserOutlineId",
                table: "Comment",
                columns: new[] { "OutlineUserUserId", "OutlineUserOutlineId" });

            migrationBuilder.CreateIndex(
                name: "IX_OutlineUser_OutlineId",
                table: "OutlineUser",
                column: "OutlineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "OutlineUser");

            migrationBuilder.DropTable(
                name: "Outlines");

            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    ChallengeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Condition = table.Column<string>(nullable: true),
                    CreaterId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FinishDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.ChallengeId);
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
                        name: "FK_ChallengeUser_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "ChallengeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChallengeUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyClass",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChallengeUserChallengeId = table.Column<int>(nullable: true),
                    ChallengeUserUserId = table.Column<string>(nullable: true),
                    Day = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyClass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyClass_ChallengeUser_ChallengeUserUserId_ChallengeUserChallengeId",
                        columns: x => new { x.ChallengeUserUserId, x.ChallengeUserChallengeId },
                        principalTable: "ChallengeUser",
                        principalColumns: new[] { "UserId", "ChallengeId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeUser_ChallengeId",
                table: "ChallengeUser",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_MyClass_ChallengeUserUserId_ChallengeUserChallengeId",
                table: "MyClass",
                columns: new[] { "ChallengeUserUserId", "ChallengeUserChallengeId" });
        }
    }
}
