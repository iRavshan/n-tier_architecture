using Microsoft.EntityFrameworkCore.Migrations;

namespace Procode.Data.Migrations
{
    public partial class EditFeedbackModelandViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDelete",
                table: "Feedbacks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isRead",
                table: "Feedbacks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "isRead",
                table: "Feedbacks");
        }
    }
}
