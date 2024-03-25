using Analysis.Business.Abstract;
using Analysis.Business.Concrete;
using Analysis.Data.AppDbContext;
using Analysis.Entities.Concrete;

namespace Analysis.Test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            ////    RepositoryBase<Analyst, int, AnalysisDbContext> dbContext = new();

            ////    var result = await dbContext.GetAll(null);
            ////    result.ToList().ForEach(x => { Console.WriteLine(x.FirstName + " " + x.LastName); });



            //// Bir cihaz örneği oluştur
            //HPLCEquipment equipment = new HPLCEquipment();


            //// Cihazın kalibrasyon geçerlilik tarihini ayarla
            //equipment.CalibrationDueDate = new DateTime(2024, 3, 15); // Örnek olarak 15 Mart 2024

            //// Analiz yapmadan önce cihazın kalibrasyon geçerliliğini kontrol et
            //AnalysisManager manager = new AnalysisManager();
            //bool CanPerformAnalysis = manager.CanPerformAnalysis(equipment);

            //// Analiz yapılabilir mi yoksa yapılamaz mı kontrol et
            //if (CanPerformAnalysis)
            //{
            //    // Analiz yapma işlemini burada gerçekleştir
            //    Console.WriteLine("Analiz yapılıyor...");
            //}
            //else
            //{
            //    // Analiz yapma işlemi reddedildi
            //    Console.WriteLine("Analiz yapılamadı.");

            //}

            var dbContext = new AnalysisDbContext(); // DbContext nesnesini oluşturun

            IDrugManager drugManager = new DrugManager();


            // Yeni ilaç oluşturun
            var newDrug = new Drug
            {
                ProductCode = "P03",
                BatchNo = "202401001",
                StorageCondition = "Refrigerator",
                DosageForm = "Capsule",
                MFGDate = new DateTime(2024, 2, 12),
                EXPDate = new DateTime(2026, 2, 11)


                // Diğer ilaç özellikleri...
            };

            try
            {
                // İlaç ekleme işlemini gerçekleştirin
                var result = drugManager.Insert(newDrug).Result;
                Console.WriteLine("İlaç başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }

        }
    }
}
