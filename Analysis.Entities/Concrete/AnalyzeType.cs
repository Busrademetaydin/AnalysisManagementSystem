using Analysis.Entities.Abstract;

namespace Analysis.Entities.Concrete
{
    public class AnalyzeType : BaseEntity<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public bool Active { get; set; }

        public ICollection<Analyze> Analyzes { get; set; }


    }
}
