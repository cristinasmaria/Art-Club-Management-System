using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class NewMigrationByAlex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Trainers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Trainers");
        }
    }
}
