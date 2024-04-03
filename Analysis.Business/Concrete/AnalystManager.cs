using Analysis.Business.Abstract;
using Analysis.Data.AppDbContext;
using Analysis.Entities.Concrete;

namespace Analysis.Business.Concrete
{
    public class AnalystManager : ManagerBase<Analyst, int, AnalysisDbContext>, IAnalystManager
    {
        public bool IsValidEmail(string email)
        {
            if (email.EndsWith("@tobiopharma.com"))
            {
                Console.WriteLine("Email adresi geçerli.");
                return true;
            }
            else
                Console.WriteLine("Geçersiz bir email adresi girdiniz. Lütfen tobiopharma domainine sahip email adresi girin.");
            return false;

        }

        public override Task<int> InsertAsync(Analyst entity)
        {
            return base.InsertAsync(entity);
        }
    }
}
