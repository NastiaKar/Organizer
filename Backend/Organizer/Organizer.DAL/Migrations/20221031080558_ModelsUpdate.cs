using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organizer.DAL.Migrations
{
    public partial class ModelsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Assignments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Assignments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
