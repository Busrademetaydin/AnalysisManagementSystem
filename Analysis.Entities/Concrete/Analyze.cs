using Analysis.Entities.Abstract;

namespace Analysis.Entities.Concrete
{
    public class Analyze : BaseEntity<int>
    {
        public string AnalyzeName { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public string? Description { get; set; }
        public int AnalystId { get; set; }
        public Analyst Analyst { get; set; }
        public int EquipmentId { get; set; }
        public HPLCEquipment? Equipment { get; set; }

        public ICollection<AnalyzeDetail> AnalyzeDetails { get; set; }


    }
}
