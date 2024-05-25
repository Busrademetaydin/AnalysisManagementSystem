using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace AnalysisManagement.WebMVC.Models
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpClient _smtpClient;
        private readonly string _fromEmail;

        public EmailSender(SmtpClient smtpClient, string fromEmail)
        {
            _smtpClient = smtpClient;
            _fromEmail = fromEmail;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_fromEmail),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };

            mailMessage.To.Add(email);

            await _smtpClient.SendMailAsync(mailMessage);
        }
    }
}
