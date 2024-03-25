using Analysis.Entities.Concrete;

namespace Analysis.Business.Abstract
{
    public interface IAnalysisManager : IManager<Analyze, int>
    {
        public bool CanPerformAnalysis(HPLCEquipment equipment);

    }
}
