using System;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationBoard.Models
{
    public static class ModelBuilderExtensions
    {

        public static void SeedJobs(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>().HasData(
                    new Job
                    {
                        JobId = 1,
                        Title = "Django Backend Developer",
                        Description = @"We are looking for a Software Engineer (Backend)\
                                        to help us as we scale out our engineering infrastructure,\ 
                                        software, and services. Should have at least 3 years experience in Python, Django and REST APIs\
                                        Talk to us if you are interested in\
                                        a fast-paced environment and if you are passionate about using technology to solve exciting problems.",
                        JobCategory = "Engineering",
                        TimeUploaded = DateTime.Now
                    },
                    new Job
                    {
                        JobId = 2,
                        Title = "Andriod Mobile Developer",
                        Description = @"Joining us would mean being part of an interdisciplinary 
team with a lofty vision of building the next-generation wealth management platform for Africans. 
This requires us to cater to the teeming population of Android mobile app users across the continent. 
We're looking for a Software engineer(Android focused) to help us achieve this goal.",
                        JobCategory = "Engineering",
                        TimeUploaded = DateTime.Now
                    },
                    new Job
                    {
                        JobId = 3,
                        Title = "Finance Manager",
                        Description = @"We are looking for a Finance Manager to strengthen our team as we march to our next growth phase.
You will be responsible for analysing everyday financial activities and keep a tab on the financial health of Cowrywise.
You will lead the development of financial reports, budget and strategies to guide executives in making sound business decisions in the short and long term.
This role requires an experienced finance professional who is able to combine strategy with execution flawlessly.",
                        JobCategory = "Finance",
                        TimeUploaded = DateTime.Now
                    }

                );
        }
    }
}
