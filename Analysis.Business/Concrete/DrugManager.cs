using Analysis.Business.Abstract;
using Analysis.Data.AppDbContext;
using Analysis.Entities.Concrete;


namespace Analysis.Business.Concrete
{
    public class DrugManager : ManagerBase<Drug, int, AnalysisDbContext>, IDrugManager
    {
        public bool CheckBatchNo(string batchNo)
        {

            var existingDrug = _repository.Get(d => d.BatchNo == batchNo).Result;
            return existingDrug != null;
        }

        public bool CheckProductCode(string productCode)
        {

            var existingDrug = _repository.Get(d => d.ProductCode == productCode).Result;
            return existingDrug != null;
        }
        public override async Task<int> InsertAsync(Drug entity)
        {

            if (CheckProductCode(entity.ProductCode))
            {
                throw new Exception("The drug with the same product code already exists.");
            }

            if (CheckBatchNo(entity.BatchNo))
            {
                throw new Exception("The drug with the same product batch number already exists.");
            }


            return await base.InsertAsync(entity);
        }
    }
}
