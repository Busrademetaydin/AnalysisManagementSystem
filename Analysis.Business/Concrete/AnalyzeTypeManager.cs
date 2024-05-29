using Analysis.Business.Abstract;
using Analysis.Data.AppDbContext;
using Analysis.Entities.Concrete;

namespace Analysis.Business.Concrete
{
    public class AnalyzeTypeManager : ManagerBase<AnalyzeType, int, AnalysisDbContext>, IAnalyzeTypeManager
    {
        public AnalyzeTypeManager()
        {

        }

        public async Task AddAnalyzeAsync(Analyze analyze)
        {
            if (analyze.AnalyzeTypeId == null)
            {
                throw new ArgumentException("AnalyzeTypeId cannot be null.");
            }

            var analyzeType = await GetByIdAsync(analyze.AnalyzeTypeId);
            if (analyzeType == null)
            {
                throw new ArgumentException("AnalyzeType not found.");
            }

            if (!analyzeType.Active)
            {
                throw new InvalidOperationException("Cannot add analyze for an inactive AnalyzeType.");
            }

            await InsertAsync(analyzeType);
        }

        public async Task UpdateAnalyzeDetailsAsync(Analyze analyze)
        {
            if (analyze.AnalyzeTypeId == null)
            {
                throw new ArgumentException("AnalyzeTypeId cannot be null.");
            }

            var analyzeType = await GetByIdAsync(analyze.AnalyzeTypeId);
            if (analyzeType == null)
            {
                throw new ArgumentException("AnalyzeType not found.");
            }

            if (!analyzeType.Active)
            {
                throw new InvalidOperationException("Cannot update analyze details for an inactive AnalyzeType.");
            }

            await UpdateAsync(analyzeType);
        }
    }
}
