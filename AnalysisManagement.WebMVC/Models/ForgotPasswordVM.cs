using System.ComponentModel.DataAnnotations;

namespace AnalysisManagement.WebMVC.Models
{
	public class ForgotPasswordVM
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }
	}
}
