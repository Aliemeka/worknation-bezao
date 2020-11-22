using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobApplicationBoard.Data;
using JobApplicationBoard.Models;

namespace JobApplicationBoard.Repositories
{
    public class JobRepo : IJobRepo
    {
        private readonly ApplicationDbContext context;

        public JobRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Job AddJob(Job job)
        {
            
            context.Jobs.Add(job);
            context.SaveChanges();
            return job;
        }

        public Job DeleteJob(int Id)
        {
            Job job = context.Jobs.Find(Id);

            if(job != null)
            {
                context.Jobs.Remove(job);
                context.SaveChanges();
            }

            return job;
        }

        public Job GetJob(int Id)
        {
            Job job = context.Jobs.Find(Id);

            return job;
        }

        public IEnumerable<Job> GetJobs()
        {
            return context.Jobs;
        }
    }
}
