using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organizer.DAL.Migrations
{
    public partial class Initial7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Users_UserId",
                table: "Boards");

            migrationBuilder.DropIndex(
                name: "IX_Boards_UserId",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Boards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Boards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Boards_UserId",
                table: "Boards",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Users_UserId",
                table: "Boards",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
