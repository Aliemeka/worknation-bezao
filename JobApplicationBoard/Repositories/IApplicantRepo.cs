using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobApplicationBoard.Models;

namespace JobApplicationBoard.Repositories
{
    interface IApplicantRepo
    {
        Applicant GetApplicant(int Id); //Gets applicant details
        IEnumerable<Applicant> GetApplicants(); //Get all applicants
        Applicant EnrolApplicant(Applicant applicant); // Enrolls a new applicant
        Applicant RejectApplicant(int Id); // Rejects an applicant
        Applicant AcceptApplicant(int Id); // Accepts an applicant
        Applicant AlertApplicant(int Id); // Sends emails to applicant
        Applicant UpdateApplication(Applicant applicantUpdates); // Updates applicants details
    }
}
