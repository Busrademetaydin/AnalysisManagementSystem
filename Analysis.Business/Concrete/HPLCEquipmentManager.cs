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
            // Aynı seri noya sahip cihaz var mı kontrol ediyoruz
            var existingEquipment = _repository.Get(d => d.SerialNumber == serialNumber).Result;
            return existingEquipment != null;
        }

        public override async Task<int> InsertAsync(HPLCEquipment entity)
        {
            // Aynı seri noya sahip cihaz varsa hata döndür
            if (CheckSerialNumber(entity.SerialNumber))
            {
                throw new Exception("Aynı seri numarasına sahip başka bir cihaz mevcut.");
            }

            return await base.InsertAsync(entity);
        }
    }
}

