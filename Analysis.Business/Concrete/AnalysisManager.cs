using Analysis.Business.Abstract;
using Analysis.Data.AppDbContext;
using Analysis.Entities.Concrete;

namespace Analysis.Business.Concrete
{
    public class AnalysisManager : ManagerBase<Analyze, int, AnalysisDbContext>, IAnalysisManager
    {
        public override Task<int> Insert(Analyze entity)
        {
            return base.Insert(entity);
        }
        public bool CanPerformAnalysis(HPLCEquipment equipment)
        {

            bool IsCalibrationValid(DateTime CalibrationDueDate)
            {
                return CalibrationDueDate >= DateTime.Today;
            }
            if (IsCalibrationValid(equipment.CalibrationDueDate))
            {
                Console.WriteLine("Analiz yapılabilir.Bu cihazın kalibrasyonu geçerli.");
                return true;
            }
            else
                Console.WriteLine("Analiz yapılamaz. Bu cihazın kalibrasyon geçerlilik tarihinin süresi dolmuş.");
            return false;


        }



    }
}
