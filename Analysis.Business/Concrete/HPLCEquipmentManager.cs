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
        public bool CheckSerialNumber(string serialNumber)
        {

            var existingEquipment = _repository.Get(d => d.SerialNumber == serialNumber).Result;
            return existingEquipment != null;
        }

        public override async Task<int> InsertAsync(HPLCEquipment entity)
        {

            if (CheckSerialNumber(entity.SerialNumber))
            {
                throw new Exception("There is another device with the same serial number.");
            }

            return await base.InsertAsync(entity);
        }
    }
}

