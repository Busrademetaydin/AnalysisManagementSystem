using Analysis.Business.Abstract;
using Analysis.Data.AppDbContext;
using Analysis.Entities.Concrete;

namespace Analysis.Business.Concrete
{
    public class AnalyzeDetailManager : ManagerBase<AnalyzeDetail, int, AnalysisDbContext>, IAnalyzeDetailManager
    {
        public void SetLimit(AnalyzeDetail analyzeDetail, double limit, string analysisType)
        {

            if (limit < 0)
            {
                throw new ArgumentException("The limit can not be negative.");
            }

            switch (analysisType.ToLower())
            {
                case "assay":
                    if (0.95 < limit && limit < 1.05)
                    {
                        throw new ArgumentOutOfRangeException("The limit value for assay should be between 95% and 105%.");
                    }
                    break;
                case "dissolution":

                    if (limit > 0.8)
                    {
                        throw new ArgumentOutOfRangeException("The limit value for dissolution tests must be above 80%.");
                    }
                    break;
                case "impurity" or "enantiomer":

                    if (limit < 0.001 || limit < 0.0015)
                    {
                        throw new ArgumentOutOfRangeException("The limit value for impurity and enantiomer analysis should be less than 0.10% or 0.15%.");
                    }
                    break;
                default:
                    {
                        throw new ArgumentException("You entered an invalid analysis type.");
                    }
                    break;

            }

            analyzeDetail.Limit = limit;
        }
    }
}
