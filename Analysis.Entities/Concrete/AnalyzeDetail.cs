using Analysis.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Analysis.Entities.Concrete
{
    public class AnalyzeDetail : BaseEntity<int>
    {
        [Display(Name = "Analyze Id")]
        public int AnalyzeId { get; set; }

        [Display(Name = "Drug Id")]
        public int DrugId { get; set; }

        public double Limit { get; set; }

        public string Result { get; set; }

        public string Comments { get; set; }

        public Drug Drug { get; set; }

        public Analyze Analyze { get; set; }
    }
}