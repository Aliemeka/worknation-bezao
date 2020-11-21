using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobApplicationBoard.Migrations
{
    public partial class SeedingJobsupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "JobCategory",
                table: "Jobs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "Description", "JobCategory", "TimeUploaded", "Title" },
                values: new object[] { 1, @"We are looking for a Software Engineer (Backend)\
                                        to help us as we scale out our engineering infrastructure,\ 
                                        software, and services. Should have at least 3 years experience in Python, Django and REST APIs\
                                        Talk to us if you are interested in\
                                        a fast-paced environment and if you are passionate about using technology to solve exciting problems.", 0, new DateTime(2020, 11, 21, 23, 0, 13, 747, DateTimeKind.Local).AddTicks(7905), "Django Backend Developer" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "Description", "JobCategory", "TimeUploaded", "Title" },
                values: new object[] { 2, @"Joining us would mean being part of an interdisciplinary 
team with a lofty vision of building the next-generation wealth management platform for Africans. 
This requires us to cater to the teeming population of Android mobile app users across the continent. 
We're looking for a Software engineer(Android focused) to help us achieve this goal.", 0, new DateTime(2020, 11, 21, 23, 0, 13, 749, DateTimeKind.Local).AddTicks(2780), "Andriod Mobile Developer" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "Description", "JobCategory", "TimeUploaded", "Title" },
                values: new object[] { 3, @"We are looking for a Finance Manager to strengthen our team as we march to our next growth phase.
You will be responsible for analysing everyday financial activities and keep a tab on the financial health of Cowrywise.
You will lead the development of financial reports, budget and strategies to guide executives in making sound business decisions in the short and long term.
This role requires an experienced finance professional who is able to combine strategy with execution flawlessly.", 1, new DateTime(2020, 11, 21, 23, 0, 13, 749, DateTimeKind.Local).AddTicks(2821), "Finance Manager" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "JobCategory",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
