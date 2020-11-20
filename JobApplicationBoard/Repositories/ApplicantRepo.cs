using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobApplicationBoard.Data;
using JobApplicationBoard.Models;

namespace JobApplicationBoard.Repositories
{
    public class ApplicantRepo : IApplicantRepo
    {
        private readonly ApplicationDbContext context;

        public ApplicantRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Applicant AcceptApplicant(int Id)
        {
            throw new NotImplementedException();
        }

        public Applicant AlertApplicant(int Id)
        {
            throw new NotImplementedException();
        }

        public Applicant EnrolApplicant(Applicant applicant)
        {
            throw new NotImplementedException();
        }

        public Applicant GetApplicant(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Applicant> GetApplicants()
        {
            throw new NotImplementedException();
        }

        public Applicant RejectApplicant(int Id)
        {
            throw new NotImplementedException();
        }

        public Applicant UpdateApplication(Applicant applicantUpdates)
        {
            throw new NotImplementedException();
        }
    }
}
