using Analysis.Business.Abstract;
using Analysis.Data.AppDbContext;
using Analysis.Entities.Concrete;


namespace Analysis.Business.Concrete
{
    public class AnalyzeTypeManager : ManagerBase<AnalyzeType, int, AnalysisDbContext>, IAnalyzeTypeManager
    {

    }

}
