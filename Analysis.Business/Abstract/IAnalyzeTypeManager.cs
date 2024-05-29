using Analysis.Entities.Concrete;

namespace Analysis.Business.Abstract
{
    public interface IAnalyzeTypeManager : IManager<AnalyzeType, int>
    {

        public Task AddAnalyzeAsync(Analyze analyze);
        public Task UpdateAnalyzeDetailsAsync(Analyze analyze);
    }

}
