using Analysis.Business.Abstract;
using Analysis.Data.AppDbContext;
using Analysis.Entities.Concrete;

namespace Analysis.Business.Concrete
{
    public class HPLCEquipmentManager : ManagerBase<HPLCEquipment, int, AnalysisDbContext>, IHPLCEquipmentManager
    {
        public bool IsCalibrationValid(DateTime CalibrationDueDate)
        {
            return CalibrationDueDate >= DateTime.Today;
        }




    }
}
