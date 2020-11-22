using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobApplicationBoard.Migrations
{
    public partial class JobsandApplicantTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    TimeUploaded = table.Column<DateTime>(nullable: false),
                    JobCategory = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobId);
                });

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    ApplicantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 25, nullable: false),
                    LastName = table.Column<string>(maxLength: 25, nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    PortfolioLink = table.Column<string>(nullable: false),
                    LevelofEduction = table.Column<string>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: false),
                    ResumePath = table.Column<string>(nullable: false),
                    CurrentStatus = table.Column<int>(nullable: false),
                    JobId = table.Column<int>(nullable: true),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.ApplicantId);
                    table.ForeignKey(
                        name: "FK_Applicants_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "Description", "JobCategory", "TimeUploaded", "Title" },
                values: new object[] { 1, @"We are looking for a Software Engineer (Backend)\
                                        to help us as we scale out our engineering infrastructure,\ 
                                        software, and services. Should have at least 3 years experience in Python, Django and REST APIs\
                                        Talk to us if you are interested in\
                                        a fast-paced environment and if you are passionate about using technology to solve exciting problems.", "Engineering", new DateTime(2020, 11, 22, 6, 8, 42, 260, DateTimeKind.Local).AddTicks(4384), "Django Backend Developer" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "Description", "JobCategory", "TimeUploaded", "Title" },
                values: new object[] { 2, @"Joining us would mean being part of an interdisciplinary 
team with a lofty vision of building the next-generation wealth management platform for Africans. 
This requires us to cater to the teeming population of Android mobile app users across the continent. 
We're looking for a Software engineer(Android focused) to help us achieve this goal.", "Engineering", new DateTime(2020, 11, 22, 6, 8, 42, 261, DateTimeKind.Local).AddTicks(4626), "Andriod Mobile Developer" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "Description", "JobCategory", "TimeUploaded", "Title" },
                values: new object[] { 3, @"We are looking for a Finance Manager to strengthen our team as we march to our next growth phase.
You will be responsible for analysing everyday financial activities and keep a tab on the financial health of Cowrywise.
You will lead the development of financial reports, budget and strategies to guide executives in making sound business decisions in the short and long term.
This role requires an experienced finance professional who is able to combine strategy with execution flawlessly.", "Finance", new DateTime(2020, 11, 22, 6, 8, 42, 261, DateTimeKind.Local).AddTicks(4657), "Finance Manager" });

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_JobId",
                table: "Applicants",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
