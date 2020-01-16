using Microsoft.EntityFrameworkCore.Migrations;

namespace CVManagement.Api.Data.Migrations
{
    public partial class UpdateCandidateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Candidates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedIn",
                table: "Candidates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Candidates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Candidates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "LinkedIn",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Candidates");
        }
    }
}
