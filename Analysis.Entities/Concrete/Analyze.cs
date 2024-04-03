using Analysis.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Analysis.Entities.Concrete
{
    public class Analyze : BaseEntity<int>
    {
        [Display(Name = "Start Date")]
        public DateOnly StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateOnly EndDate { get; set; }

        public string? Description { get; set; }
        [Display(Name = "Analyst Id")]
        public int AnalystId { get; set; }
        public Analyst Analyst { get; set; }
        [Display(Name = "Equipment Id")]
        public int EquipmentId { get; set; }
        public HPLCEquipment? Equipment { get; set; }
        [Display(Name = "Analyze Type Id")]
        public int AnalyzeTypeId { get; set; }
        public AnalyzeType AnalyzeType { get; set; }

        public ICollection<AnalyzeDetail> AnalyzeDetails { get; set; }


    }
}
