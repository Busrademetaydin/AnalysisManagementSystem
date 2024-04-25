using Analysis.Business.Abstract;
using Analysis.Data.AppDbContext;
using Analysis.Entities.Concrete;

namespace Analysis.Business.Concrete
{
    public class AnalyzeDetailManager : ManagerBase<AnalyzeDetail, int, AnalysisDbContext>, IAnalyzeDetailManager
    {
        public void SetLimit(AnalyzeDetail analyzeDetail, int limit, string analysisType)
        {

            if (limit < 0)
            {
                throw new ArgumentException("Limit değeri negatif olamaz.");
            }

            switch (analysisType.ToLower())
            {
                case "assay":
                    // Assay analizleri için limit aralığı %95-105
                    if (0.95 < limit && limit < 1.05)
                    {
                        throw new ArgumentOutOfRangeException("Assay analizleri için limit değeri %95 ile %105 arasında olmalıdır.");
                    }
                    break;
                case "dissolution":
                    // Dissolüsyon analizleri için limit %80 üzeri
                    if (limit > 0.8)
                    {
                        throw new ArgumentOutOfRangeException("Dissolüsyon analizleri için limit değeri %80'in üzerinde olmalıdır.");
                    }
                    break;
                case "impurity" or "enantiomer":
                    // Safsızlık ve enantiyomer analizleri için limit 
                    if (limit < 0.001 || limit < 0.0015)
                    {
                        throw new ArgumentOutOfRangeException("Safsızlık ve enantiyomer analizleri için limit değeri %0.10 veya %0.15 den az olmalıdır.");
                    }
                    break;
                default:
                    {
                        throw new ArgumentException("Geçersiz bir analiz türü girdiniz");
                    }
                    break;

            }

            analyzeDetail.Limit = limit;
        }
    }
}
