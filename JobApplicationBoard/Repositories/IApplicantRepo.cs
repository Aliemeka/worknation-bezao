using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobApplicationBoard.Models;

namespace JobApplicationBoard.Repositories
{
    public interface IApplicantRepo
    {
        Applicant GetApplicant(int Id); //Gets applicant details
        IEnumerable<Applicant> GetApplicants(); //Get all applicants
        IEnumerable<Applicant> GetAcceptedApplicants(); // Gets list of accepted applicants
        IEnumerable<Applicant> GetRejectedApplicants(); // Gets list of rejected applicants
        Applicant EnrolApplicant(Applicant applicant); // Enrolls a new applicant
        Applicant RejectApplicant(int Id); // Rejects an applicant
        Applicant AcceptApplicant(int Id); // Accepts an applicant
        string GetApplicationStatus(int Id); //Gets Application status
        Applicant UpdateApplication(Applicant applicantUpdates); // Updates applicants details
    }
}
