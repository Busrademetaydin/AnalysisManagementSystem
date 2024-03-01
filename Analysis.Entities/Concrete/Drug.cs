using Analysis.Entities.Abstract;

namespace Analysis.Entities.Concrete
{
    public class Drug : BaseEntity<int>
    {
        public string ProductCode { get; set; }

        public string BatchNo { get; set; }
        public string? Description { get; set; }

        public string DosageForm { get; set; }
        public DateTime MFGDate { get; set; }
        public DateTime EXPDate { get; set; }
        public string StorageCondition { get; set; }
        public ICollection<AnalyzeDetail> AnalyzeDetails { get; set; }


    }
}
