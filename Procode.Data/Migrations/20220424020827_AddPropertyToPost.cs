using Microsoft.EntityFrameworkCore.Migrations;

namespace Procode.Data.Migrations
{
    public partial class AddPropertyToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorUsername",
                table: "Posts",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorUsername",
                table: "Posts");
        }
    }
}
