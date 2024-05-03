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

            if (!entity.Email.EndsWith("@tobiopharma.com"))
            {

                throw new Exception("Geçersiz bir email adresi girdiniz. Lütfen tobiopharma domainine sahip email adresi girin.");
            }

            if (entity.IdentificationNumber.Length != 11)
            {

                throw new Exception("11 karaktere sahip unique bir kimlik numarası giriniz.");

            }

            if (!IsValidEmail(entity.Email) || !IsValidIDNo(entity.IdentificationNumber))
            {

                throw new Exception("Bu email adresi veya kimlik numarası zaten kullanımda.");
            }

            return await base.InsertAsync(entity);



        }

    }
}

