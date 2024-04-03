using Analysis.Entities.Concrete;

namespace Analysis.Business.Abstract
{
    public interface IDrugManager : IManager<Drug, int>
    {
        //Aynı koda sahip ilaç olmasın.
        public bool CheckProductCode(string productCode);

        //Aynı seri noya sahip ilaç olamaz
        public bool CheckBatchNo(string batchNo);
    }
}
