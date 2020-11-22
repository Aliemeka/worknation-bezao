using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobApplicationBoard.Data;
using JobApplicationBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationBoard.Repositories
{
    public class ApplicantRepo : IApplicantRepo
    {
        private readonly ApplicationDbContext context;

        public ApplicantRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        //Accepts Applicant application
        public Applicant AcceptApplicant(int Id)
        {
            Applicant applicant = context.Applicants.Find(Id);
            applicant.CurrentStatus = Status.Accepted;

            var acceptedApplicant = context.Applicants.Attach(applicant);
            acceptedApplicant.State = EntityState.Modified;
            return applicant;
        }

        // Executes when user enrolls
        public Applicant EnrolApplicant(Applicant applicant)
        {
            context.Applicants.Add(applicant);
            return applicant;
        }

        public IEnumerable<Applicant> GetAcceptedApplicants()
        {
            throw new NotImplementedException();
        }

        public Applicant GetApplicant(int Id)
        {
            return context.Applicants.Find(Id);
        }

        public IEnumerable<Applicant> GetApplicants()
        {
            return context.Applicants;
        }

        public string GetApplicationStatus(int Id)
        {
            Applicant applicant = context.Applicants.Find(Id);
            return applicant.CurrentStatus.ToString();
        }

        public IEnumerable<Applicant> GetRejectedApplicants()
        {
            throw new NotImplementedException();
        }

        public Applicant RejectApplicant(int Id)
        {
            Applicant applicant = context.Applicants.Find(Id);
            applicant.CurrentStatus = Status.Rejected;

            var rejectedApplicant = context.Applicants.Attach(applicant);
            rejectedApplicant.State = EntityState.Modified;

            return applicant;
        }

        // Executes anytime user updates their application
        public Applicant UpdateApplication(Applicant applicantUpdates)
        {
            var updatedApplicant = context.Applicants.Attach(applicantUpdates);
            updatedApplicant.State = EntityState.Modified;
            return applicantUpdates;
        }
    }
}
