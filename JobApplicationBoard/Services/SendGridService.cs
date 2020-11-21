using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using Newtonsoft.Json;

namespace JobApplicationBoard.Services
{
    public class SendGridService
    {
        public Task SendMessage(string message, string recieverEmail, string recieverName)
        {
            // Gets SendGrid API key from environment variables
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_KEY");

            var templateId = Environment.GetEnvironmentVariable("TEMPLATE_ID");

            //Creates SendGrid email client
            var emailClient = new SendGridClient(apiKey); 

            //Initiates email response object
            var mailResponse = new SendGridMessage();

            // Declares sender email and name
            mailResponse.SetFrom("devgbono@gmail.com", "Careers at WorkNation");

            // Declares the reciever's email and name
            mailResponse.AddTo(recieverEmail, recieverName);

            //Sets email subject
            mailResponse.SetSubject("Careers at WorkNation");
            //directs API to dynamic template created in SendGrid dashboard
            mailResponse.SetTemplateId(templateId); 

            //Appends the dynamic email contents
            mailResponse.SetTemplateData(new EmailContent
            {
                Message = message,
            });
            return emailClient.SendEmailAsync(mailResponse);

        }

        private class EmailContent
        {
            [JsonProperty("message")]
            public string Message { get; set; }
        }
    }
}
