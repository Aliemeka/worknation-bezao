using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobApplicationBoard.Models;

namespace JobApplicationBoard.Repositories
{
    public interface IJobRepo
    {
        Job GetJob(int Id);
        IEnumerable<Job> GetJobs();
        Job AddJob(Job job);
        Job DeleteJob(int Id);
    }
}
