using Analysis.Entities.Concrete;

namespace Analysis.Business.Abstract
{
    public interface IAnalyzeDetailManager : IManager<AnalyzeDetail, int>
    {
        public void SetLimit(AnalyzeDetail analyzeDetail, double limit, string analysisType);

    }

}
