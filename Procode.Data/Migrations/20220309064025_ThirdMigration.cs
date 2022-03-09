using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Procode.Data.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContentId",
                table: "Speakers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Speakers_ContentId",
                table: "Speakers",
                column: "ContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Speakers_Contents_ContentId",
                table: "Speakers",
                column: "ContentId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speakers_Contents_ContentId",
                table: "Speakers");

            migrationBuilder.DropIndex(
                name: "IX_Speakers_ContentId",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "ContentId",
                table: "Speakers");
        }
    }
}
