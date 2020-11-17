using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using Newtonsoft.Json;

namespace JobApplicationBoard.Services
{
    public class SendGridService
    {
        public async Task SendMessage(string message, string recieverEmail, string recieverName)
        {
            // Gets SendGrid API key from environment variables
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_KEY");
            //Creates SendGrid email client
            var emailClient = new SendGridClient(apiKey); 

            //Initiates email response object
            var mailResponse = new SendGridMessage();
            // Declares sender email and name
            mailResponse.SetFrom("devgbono@gmail.com", "Careers at WorkNation");
            // Declares the reciever's email and name
            mailResponse.AddTo(recieverEmail, recieverName);
            //directs API to dynamic template created in SendGrid dashboard
            mailResponse.SetTemplateId("d-b766d34f870e4c6eb145de10b9725db7"); 

            //Appends the dynamic email contents
            mailResponse.SetTemplateData(new EmailContent
            {
                Message = message,
            });
            var response = await emailClient.SendEmailAsync(mailResponse);

        }

        private class EmailContent
        {
            [JsonProperty("message")]
            public string Message { get; set; }
        }
    }
}
