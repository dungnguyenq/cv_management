using Microsoft.EntityFrameworkCore.Migrations;

namespace CVManagement.Api.Data.Migrations
{
    public partial class UpdateCandidateTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CV",
                table: "Candidates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Candidates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CV",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Candidates");
        }
    }
}
