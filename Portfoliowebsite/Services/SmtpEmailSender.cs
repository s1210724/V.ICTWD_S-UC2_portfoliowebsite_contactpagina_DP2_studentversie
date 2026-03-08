using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace Portfoliowebsite.Services
{
    public class SmtpEmailSender : IEmailSender
    {
        // add config to get the email and pass from local secrets
        private readonly IConfiguration _configuration;

        public SmtpEmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendAsync(string Name, string Email, string Subject, string Message)
        {
            using (var smtp = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                EnableSsl = false,
                Credentials = new NetworkCredential(
                    _configuration["MailUser"], 
                    _configuration["MailPass"])
            })
            using (var mail = new MailMessage())
            {
                mail.From = new MailAddress("noreply@example.com", "Website");
                mail.To.Add("contact@example.com");
                mail.Subject = $"Contact: {Subject}";
                mail.Body = $"Naam: {Name}\nEmail: {Email}\nBericht:\n{Message}";

                await smtp.SendMailAsync(mail);
            }
        }
    }
}
