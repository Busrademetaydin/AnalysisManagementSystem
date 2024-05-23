using System.Net.Mail;

namespace AnalysisManagement.WebMVC.Models
{
    public class EmailHelper
    {
        public async Task<bool> SendEmail(string email, string message)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("busrademet16@gmail.com");
            mailMessage.To.Add(email);
            mailMessage.Body = message;
            mailMessage.Subject = "Analiz Yönetim Kayit Mail onaylama";
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Credentials = new System.Net.NetworkCredential("busrademet16@gmail.com", "zoexmxynmvtupauk");
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Host = " smtp.gmail.com";
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                smtpClient.Send(mailMessage);

                return true;

            }
            catch (Exception ex)
            {

                return false;
            }

            return true;
        }
    }

}
