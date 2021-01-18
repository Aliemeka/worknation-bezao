﻿// <auto-generated />
using System;
using JobApplicationBoard.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobApplicationBoard.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobApplicationBoard.Models.Applicant", b =>
                {
                    b.Property<int>("ApplicantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppliedJob")
                        .HasColumnType("int");

                    b.Property<int>("CurrentStatus")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("LevelofEduction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PortfolioLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResumePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("ApplicantId");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("JobApplicationBoard.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeUploaded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobId");

                    b.ToTable("Jobs");

                    b.HasData(
                        new
                        {
                            JobId = 1,
                            Description = @"We are looking for a Software Engineer (Backend)\
                                        to help us as we scale out our engineering infrastructure,\ 
                                        software, and services. Should have at least 3 years experience in Python, Django and REST APIs\
                                        Talk to us if you are interested in\
                                        a fast-paced environment and if you are passionate about using technology to solve exciting problems.",
                            JobCategory = "Engineering",
                            TimeUploaded = new DateTime(2021, 1, 18, 11, 49, 54, 708, DateTimeKind.Local).AddTicks(7274),
                            Title = "Django Backend Developer"
                        },
                        new
                        {
                            JobId = 2,
                            Description = @"Joining us would mean being part of an interdisciplinary 
team with a lofty vision of building the next-generation wealth management platform for Africans. 
This requires us to cater to the teeming population of Android mobile app users across the continent. 
We're looking for a Software engineer(Android focused) to help us achieve this goal.",
                            JobCategory = "Engineering",
                            TimeUploaded = new DateTime(2021, 1, 18, 11, 49, 54, 721, DateTimeKind.Local).AddTicks(7074),
                            Title = "Andriod Mobile Developer"
                        },
                        new
                        {
                            JobId = 3,
                            Description = @"We are looking for a Finance Manager to strengthen our team as we march to our next growth phase.
You will be responsible for analysing everyday financial activities and keep a tab on the financial health of Cowrywise.
You will lead the development of financial reports, budget and strategies to guide executives in making sound business decisions in the short and long term.
This role requires an experienced finance professional who is able to combine strategy with execution flawlessly.",
                            JobCategory = "Finance",
                            TimeUploaded = new DateTime(2021, 1, 18, 11, 49, 54, 721, DateTimeKind.Local).AddTicks(7259),
                            Title = "Finance Manager"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
