using Analysis.Entities.Abstract;

namespace Analysis.Entities.Concrete
{
    public class Role : BaseEntity<int>
    {
        public string RoleName { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}