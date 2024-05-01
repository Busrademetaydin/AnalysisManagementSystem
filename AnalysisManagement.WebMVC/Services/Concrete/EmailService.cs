using AnalysisManagement.WebMVC.Services.Abstract;

namespace AnalysisManagement.WebMVC.Services.Concrete
{
	public class EmailService : IEmailService
	{
		public void SendEmail(string to, string subject, string body)
		{
			//string fromAddress = "your-email@example.com";
			//string password = "your-email-password";
			//string smtpServer = "smtp.example.com";
			//int port = 587; // Genellikle SMTP için kullanılan port numarası

			//var message = new MimeMessage();
			//message.From.Add(new MailboxAddress(fromAddress));
			//message.To.Add(new MailboxAddress(to));
			//message.Subject = subject;

			//message.Body = new TextPart("plain")
			//{
			//	Text = body
			//};


			//using (var client = new SmtpClient())
			//{
			//	client.Connect(smtpServer, port, false);
			//	client.Authenticate(fromAddress, password);
			//	client.Send(message);
			//	client.Disconnect(true);
			//}
		}
	}
}
