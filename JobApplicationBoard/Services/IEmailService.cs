using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApplicationBoard.Services
{
    public interface IEmailService
    {
        Task SendEmail(string feedback, string recieverEmail, string recieverName);

        Task SendConfirmation(string recieverEmail, string recieverName);

    }
}
