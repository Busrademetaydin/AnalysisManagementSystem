using Analysis.Business.Abstract;
using Analysis.Data.AppDbContext;
using Analysis.Entities.Concrete;

namespace Analysis.Business.Concrete
{
    public class AnalysisManager : ManagerBase<Analyze, int, AnalysisDbContext>, IAnalysisManager
    {
        public bool CanPerformAnalysis(HPLCEquipment equipment)
        {

            bool IsCalibrationValid(DateTime CalibrationDueDate)
            {
                return CalibrationDueDate >= DateTime.Today;
            }
            if (IsCalibrationValid(equipment.CalibrationDueDate))
            {
                Console.WriteLine("Analysis can be done. The calibration of this device is valid.");
                return true;
            }
            else
                Console.WriteLine("Analysis cannot be done. This device's calibration validity period has expired.");
            return false;


        }

        public override Task<int> InsertAsync(Analyze entity)
        {
            return base.InsertAsync(entity);
        }

        public Task InsertAsync(AnalyzeDetail analysisDetail)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(AnalyzeDetail update)
        {
            throw new NotImplementedException();
        }
    }
}
