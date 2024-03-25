using Analysis.Entities.Concrete;

namespace Analysis.Business.Abstract
{
    public interface IHPLCEquipmentManager : IManager<HPLCEquipment, int>
    {
        public bool IsCalibrationValid(DateTime CalibrationDueDate);

    }
}
