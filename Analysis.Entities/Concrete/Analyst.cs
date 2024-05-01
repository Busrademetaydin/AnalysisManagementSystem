using Analysis.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Analysis.Entities.Concrete
{
    public class Analyst : BaseEntity<int>
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public bool? Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        [Display(Name = "Identification Number")]
        public string IdentificationNumber { get; set; }
        public string Title { get; set; }


        public ICollection<Analyze>? Analyzes { get; set; }




    }
}
