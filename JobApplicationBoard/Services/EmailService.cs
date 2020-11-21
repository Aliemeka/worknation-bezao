

namespace JobApplicationBoard.Services
{

    public class EmailService : IEmailService
    {

        //
        // Summary:
        //     Gets or sets an feedback type
        //     Feedback can be "New Entry", "Recieved", "Accepted"
        public string Feedback { get; set; }
        //
        // Summary:
        //     Gets or sets the email of the reciever
        //     who should receive responses to based on the feedback.
        public string RecieverEmail { get; set; }
        //
        // Summary:
        //     Gets or sets the name of the reciever
        //     based on feedback response
        public string RecieverName { get; set; }


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
        public void SendEmail()
        {
            string message = SetEmailMessage(Feedback);
            var mailSender = new SendGridService();
            mailSender.SendMessage(message, RecieverEmail, RecieverName).Wait();
        }
    }
}

