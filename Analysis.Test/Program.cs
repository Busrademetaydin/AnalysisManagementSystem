namespace Analysis.Test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            //RepositoryBase<Analyst, int, AnalysisDbContext> dbContext = new();

            //var result = await dbContext.GetAllAsync(null);
            //result.ToList().ForEach(x => { Console.WriteLine(x.FirstName + " " + x.LastName); });



            //HPLCEquipment equipment = new HPLCEquipment();

            //equipment.CalibrationDueDate = new DateTime(2024, 3, 15); // Örnek olarak 15 Mart 2024

            //// Analiz yapmadan önce cihazın kalibrasyon geçerliliğini kontrol et
            //AnalysisManager manager = new AnalysisManager();
            //bool CanPerformAnalysis = manager.CanPerformAnalysis(equipment);

            // Analiz yapılabilir mi yoksa yapılamaz mı kontrol et
            //if (CanPerformAnalysis)
            //{

            //    Console.WriteLine("Analiz için hazırlıklar tamam.");
            //}
            //else
            //{

            //    Console.WriteLine("Analiz yapılamaz.");

            //}

            //var dbContext = new AnalysisDbContext();

            //IDrugManager drugManager = new DrugManager();

            //var newDrug = new Drug
            //{
            //    ProductCode = "P03",
            //    BatchNo = "241001001",
            //    Description = "Paracetamol 500 mg",
            //    StorageCondition = "Refrigerator",
            //    DosageForm = "Tablet",
            //    MFGDate = new DateTime(2024, 2, 12),
            //    EXPDate = new DateTime(2026, 2, 11)


            //};

            //try
            //{
            //    var result = drugManager.InsertAsync(newDrug).Result;
            //    Console.WriteLine("İlaç başarıyla eklendi.");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Hata: {ex.Message}");
            //}

            //IHPLCEquipmentManager equipmentManager = new HPLCEquipmentManager();
            //var equipment = new HPLCEquipment
            //{ Brand = "Waters", CalibrationDueDate = new DateTime(2024, 05, 06), SerialNumber = "U145502" };


            //try
            //{
            //    var result = equipmentManager.InsertAsync(equipment).Result;
            //    Console.WriteLine("Ekipman bilgileri başarılı bir şekilde kaydedildi.");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Hata: {ex.Message}");
            //}


            //IAnalystManager analystManager = new AnalystManager();

            //var analyst = new Analyst
            //{
            //    FirstName = "Büşra",
            //    LastName = "Demet Aydın",
            //    Gender = true,
            //    IdentificationNumber = "12312312313",
            //    Email = "busrademet@tobiopharma.com",
            //    Phone = "536589652300",
            //    Title = "Uzman"

            //};

            //try
            //{
            //    await analystManager.InsertAsync(analyst);
            //    Console.WriteLine("Analyst added succesfully.");
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine("Error" + ex.Message);
            //}


        }
    }
}
