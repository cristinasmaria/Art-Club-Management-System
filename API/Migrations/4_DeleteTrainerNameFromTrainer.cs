using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class DeleteTrainerNameFromTrainer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Trainers");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Events",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Trainers",
                nullable: true);
        }
    }
}
