using Analysis.Entities.Abstract;

namespace Analysis.Entities.Concrete
{
    public class HPLCEquipment : BaseEntity<int>
    {
        public string Brand { get; set; }

        public string SerialNumber { get; set; }
        public DateTime CalibrationDueDate { get; set; }

        public ICollection<Analyze> Analyzes { get; set; }
    }
}
