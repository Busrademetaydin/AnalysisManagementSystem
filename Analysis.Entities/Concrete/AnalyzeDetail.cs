using Analysis.Entities.Abstract;

namespace Analysis.Entities.Concrete
{
    public class AnalyzeDetail : BaseEntity<int>
    {
        public int AnalyzeId { get; set; }

        public int DrugId { get; set; }

        public int Limit { get; set; }

        public string Result { get; set; }

        public string Comments { get; set; }

        public Drug Drug { get; set; }

        public Analyze Analyze { get; set; }
    }
}