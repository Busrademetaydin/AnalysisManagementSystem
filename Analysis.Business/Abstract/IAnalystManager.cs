using Analysis.Entities.Concrete;

namespace Analysis.Business.Abstract
{
    public interface IAnalystManager : IManager<Analyst, int>
    {
        //public void AddAnalyst(Analyst analyst)
        //{
        //    // Örnek bir iş kuralı: Geçerli bir e-posta adresi sağlanıp sağlanmadığını kontrol etmek
        //    if (!IsValidEmail(analyst.Email))
        //    {
        //        throw new ArgumentException("Geçerli bir e-posta adresi sağlayınız.");
        //    }

        //    // Burada başka iş kurallarınızı da ekleyebilirsiniz

        //    // Analist ekleme işlemi burada gerçekleştirilir
        //    // Örnek: analystRepository.Add(analyst);
        //}

        //private bool IsValidEmail(string email)
        //{
        //    // Basit bir e-posta adresi doğrulama
        //    try
        //    {
        //        var addr = new System.Net.Mail.MailAddress(email);
        //        return addr.Address == email;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public bool IsValidEmail(string email);

        public bool IsValidIDNo(string identificationNumber)
        {
            if (string.IsNullOrEmpty(identificationNumber) || identificationNumber.Length != 11)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

}
