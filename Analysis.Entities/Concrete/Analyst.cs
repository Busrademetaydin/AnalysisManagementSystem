using Analysis.Entities.Abstract;

namespace Analysis.Entities.Concrete
{
    public class Analyst : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string IdentificationNumber { get; set; }
        public string Title { get; set; }


        public ICollection<Analyze> Analyzes { get; set; }




    }
}
