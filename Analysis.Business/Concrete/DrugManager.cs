using Analysis.Business.Abstract;
using Analysis.Data.AppDbContext;
using Analysis.Entities.Concrete;


namespace Analysis.Business.Concrete
{
    public class DrugManager : ManagerBase<Drug, int, AnalysisDbContext>, IDrugManager
    {
        public bool CheckBatchNo(string batchNo)
        {
            // Aynı ürün batch numarasına sahip bir ilaç var mı kontrol 
            var existingDrug = _repository.Get(d => d.BatchNo == batchNo).Result;
            return existingDrug != null;
        }

        public bool CheckProductCode(string productCode)
        {
            // Aynı ürün koduna sahip bir ilaç var mı kontrol
            var existingDrug = _repository.Get(d => d.ProductCode == productCode).Result;
            return existingDrug != null;
        }
        public override async Task<int> InsertAsync(Drug entity)
        {

            if (CheckProductCode(entity.ProductCode))
            {
                throw new Exception("Aynı ürün koduna sahip ilaç zaten mevcut.");
            }

            if (CheckBatchNo(entity.BatchNo))
            {
                throw new Exception("Aynı ürün batch numarasına sahip ilaç zaten mevcut.");
            }

            // Kontrollerden geçtiyse ilacı ekle
            return await base.InsertAsync(entity);
        }
    }
}
