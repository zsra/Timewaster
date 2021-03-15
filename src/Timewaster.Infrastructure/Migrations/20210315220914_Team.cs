using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Timewaster.Infrastructure.Migrations
{
    public partial class Team : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "team",
                incrementBy: 10);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReferenceKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    PartitionKey = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamId",
                table: "Users",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TeamId",
                table: "Projects",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Teams_TeamId",
                table: "Projects",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Teams_TeamId",
                table: "Users",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Teams_TeamId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Teams_TeamId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Users_TeamId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Projects_TeamId",
                table: "Projects");

            migrationBuilder.DropSequence(
                name: "team");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Projects");
        }
    }
}
