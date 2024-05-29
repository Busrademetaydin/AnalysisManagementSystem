using Analysis.Business.Abstract;
using Analysis.Data.AppDbContext;
using Analysis.Entities.Concrete;

namespace Analysis.Business.Concrete
{
    public class AnalystManager : ManagerBase<Analyst, int, AnalysisDbContext>, IAnalystManager
    {
        public bool IsValidIDNo(string identificationNumber)

        {
            var existingAnalyst = _repository.Get(d => d.IdentificationNumber == identificationNumber).Result;
            return existingAnalyst != null;
        }

        public bool IsValidEmail(string email)
        {
            var existingAnalyst = _repository.Get(d => d.Email == email).Result;
            return existingAnalyst != null;
        }

        public override async Task<int> InsertAsync(Analyst entity)
        {

            if (entity.IdentificationNumber.Length != 11)
            {

                throw new Exception("Enter a unique identification number with 11 characters.");

            }

            if (IsValidEmail(entity.Email) || IsValidIDNo(entity.IdentificationNumber))
            {

                throw new Exception("This email address or ID number is already in use.");
            }

            return await base.InsertAsync(entity);



        }

    }
}

