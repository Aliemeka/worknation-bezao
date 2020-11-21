using Microsoft.EntityFrameworkCore.Migrations;

namespace JobApplicationBoard.Migrations
{
    public partial class AddedEntitystates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Applicants",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Applicants");
        }
    }
}
