using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobApplicationBoard.Models;

namespace JobApplicationBoard.Repositories
{
    public class MockJobsRepo : IJobRepo
    {
        private List<Job> _jobList;

        private const string description = @"They of course valued this knowledge, and they wanted the same from their iOS hire. In particular, they wanted a strong native iOS engineer to architect and build their native app from scratch, with the following interview and experience requirements";

        public MockJobsRepo()
        {
            _jobList = new List<Job>()
            {
                new Job() { JobId= 1, Title="Django Backend Engineer", Description=description, JobCategory="Engineering", TimeUploaded = new DateTime()},
                new Job() { JobId= 2, Title="React.js Developer", Description=description, JobCategory="Engineering", TimeUploaded = new DateTime()},
                new Job() { JobId= 3, Title="Content Writer", Description=description, JobCategory="Marketing", TimeUploaded = new DateTime()},
                new Job() { JobId= 4, Title="UI/UX Designer", Description=description, JobCategory="Design", TimeUploaded = new DateTime()},
                new Job() { JobId= 5, Title="Product Manager", Description=description, JobCategory="Product", TimeUploaded = new DateTime()},
            };
        }
        public Job AddJob(Job job)
        {
            _jobList.Add(job);
            return job;
        }

        public Job DeleteJob(int Id)
        {
            Job dJob = _jobList.FirstOrDefault(e => e.JobId == Id);

            if(dJob != null)
            {
                _jobList.Remove(dJob);
            }

            return dJob;
        }

        public Job GetJob(int Id)
        {
            return _jobList.Find(e=> e.JobId == Id);
        }

        public IEnumerable<Job> GetJobs()
        {
            return _jobList;
        }
    }
}
