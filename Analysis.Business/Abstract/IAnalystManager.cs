using Analysis.Entities.Concrete;

namespace Analysis.Business.Abstract
{
    public interface IAnalystManager : IManager<Analyst, int>
    {
        public bool IsValidEmail(string email);
        public bool IsValidIDNo(string identificationNumber);



    }

}
