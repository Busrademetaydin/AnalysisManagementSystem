using AnalysisManagement.WebMVC.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AnalysisManagement.WebMVC.Controllers
{
	public class ForgotPasswordController : Controller
	{
		private readonly IEmailService _emailService;

		public ForgotPasswordController(IEmailService emailService)
		{
			_emailService = emailService;
		}

		//[HttpPost]
		//public IActionResult ForgotPassword(string email)
		//{
		//	// Kullanıcıya ait e-posta adresine şifre sıfırlama bağlantısını içeren bir e-posta gönder
		//	string resetLink = GenerateResetLink(email);
		//	_emailService.SendEmail(email, "Şifre Sıfırlama", $"Şifrenizi sıfırlamak için <a href='{resetLink}'>buraya tıklayın</a>.");

		//	// Başarılı bir şekilde e-posta gönderildiğini belirten bir mesaj döndür
		//	return View("ForgotPasswordConfirmation");
		//}

		//private string GenerateResetLink(string email)
		//{
		//	// E-posta adresine bağlı olarak şifre sıfırlama bağlantısını oluştur
		//	// Bu bağlantı genellikle bir token içerir ve kullanıcıyı şifre sıfırlama formuna yönlendirir
		//	// Örnek olarak, token içeren bir URL döndürebilirsiniz:
		//	// return Url.Action("ResetPassword", "Account", new { email = email, token = resetToken }, Request.Scheme);
		//}
	}
}

