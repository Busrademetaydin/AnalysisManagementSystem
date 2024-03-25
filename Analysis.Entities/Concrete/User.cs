using Analysis.Entities.Abstract;

namespace Analysis.Entities.Concrete
{
    public class User : BaseEntity<int>
    {


        public string UserName { get; set; }
        public string Password { get; set; }

        public ICollection<Role>? Roles { get; set; }


    }
}
