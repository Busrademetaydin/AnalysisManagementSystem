using Microsoft.AspNetCore.Identity;

namespace Analysis.Entities.Concrete
{

	public class AppUser : IdentityUser
	{
		public string? TcNo { get; set; }


	}
}
