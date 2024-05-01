using Analysis.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Analysis.Entities.Concrete
{
    public class HPLCEquipment : BaseEntity<int>
    {
        public string Brand { get; set; }

        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        [Display(Name = "Calibration Due Date")]
        public DateTime CalibrationDueDate { get; set; }

        public ICollection<Analyze> Analyzes { get; set; }


    }
}
