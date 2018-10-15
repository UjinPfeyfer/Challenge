using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Challenge24.Data.Migrations
{
    public partial class string_in_challengeUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyClass",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChallengeUserChallengeId = table.Column<int>(nullable: true),
                    ChallengeUserUserId = table.Column<string>(nullable: true),
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
                name: "IX_MyClass_ChallengeUserUserId_ChallengeUserChallengeId",
                table: "MyClass",
                columns: new[] { "ChallengeUserUserId", "ChallengeUserChallengeId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyClass");
        }
    }
}
