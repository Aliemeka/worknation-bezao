using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobApplicationBoard.Migrations
{
    public partial class Updatedapplicantmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Jobs_JobId",
                table: "Applicants");

            migrationBuilder.DropIndex(
                name: "IX_Applicants_JobId",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Applicants");

            migrationBuilder.AddColumn<int>(
                name: "AppliedJob",
                table: "Applicants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                column: "TimeUploaded",
                value: new DateTime(2021, 1, 18, 11, 49, 54, 708, DateTimeKind.Local).AddTicks(7274));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 2,
                column: "TimeUploaded",
                value: new DateTime(2021, 1, 18, 11, 49, 54, 721, DateTimeKind.Local).AddTicks(7074));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 3,
                column: "TimeUploaded",
                value: new DateTime(2021, 1, 18, 11, 49, 54, 721, DateTimeKind.Local).AddTicks(7259));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppliedJob",
                table: "Applicants");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Applicants",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                column: "TimeUploaded",
                value: new DateTime(2020, 11, 22, 6, 8, 42, 260, DateTimeKind.Local).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 2,
                column: "TimeUploaded",
                value: new DateTime(2020, 11, 22, 6, 8, 42, 261, DateTimeKind.Local).AddTicks(4626));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 3,
                column: "TimeUploaded",
                value: new DateTime(2020, 11, 22, 6, 8, 42, 261, DateTimeKind.Local).AddTicks(4657));

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_JobId",
                table: "Applicants",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Jobs_JobId",
                table: "Applicants",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
