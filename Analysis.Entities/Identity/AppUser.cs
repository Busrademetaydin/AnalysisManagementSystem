using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Analysis.Entities.Concrete
{

    public class AppUser : IdentityUser
    {
        [MaxLength(11)]
        public string? TcNo { get; set; }

        public bool IsDelete { get; set; } = false;


    }
}
