using Microsoft.EntityFrameworkCore.Migrations;

namespace Procode.Data.Migrations
{
    public partial class EditContentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailUrl",
                table: "Contents");

            migrationBuilder.RenameColumn(
                name: "VideoUrl",
                table: "Contents",
                newName: "YouTubeVideoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YouTubeVideoID",
                table: "Contents",
                newName: "VideoUrl");

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailUrl",
                table: "Contents",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
