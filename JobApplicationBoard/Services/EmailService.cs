

using System.Threading.Tasks;

namespace JobApplicationBoard.Services
{

    public class EmailService : IEmailService
    {


        //Set the message acccording to the feedback. If there is an applicant id it also appends that to the message
        private string SetEmailMessage(string feedback, string applicantId="")
        {
            switch (feedback)
            {
                case "New Entry":
                    return "There is a new entry in the application " + applicantId;

                case "Recieved":
                    return @"Your Application has been recieved and is currently being reviewed
                            Due to the high volume of applications, you may recieve a response within 5 to 10 days";

                case "Accepted":
                    return @"Congratulations! Your Application was accepted. 
                            You have been selected to move forward to the interview stage. The interview date
                            and location will be send to you within 4 to 5 days";
                default:
                    return "0";
            }
        }


        //Inititates the SendGrid service to send email via the api
        public Task SendEmail(string feedback, string recieverEmail, string recieverName)
        {
            string message = SetEmailMessage(feedback);
            var mailSender = new SendGridService();
            return mailSender.SendMessage(message, recieverEmail, recieverName);
        }

        //Confirmation email sender
        public Task SendConfirmation(string message, string recieverEmail, string recieverName)
        {
            var mailSender = new SendGridService();
            return mailSender.SendMessage(message, recieverEmail, recieverName);
        }
    }
}

