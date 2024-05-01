using Analysis.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Analysis.Entities.Concrete
{
	public class Drug : BaseEntity<int>
	{
		[Display(Name = "Product Code")]
		public string ProductCode { get; set; }

		[Display(Name = "Batch No")]
		public string BatchNo { get; set; }
		public string? Description { get; set; }
		[Display(Name = "Dosage Form")]
		public string DosageForm { get; set; }

		[Display(Name = "Manufacturing Date")]
		public DateTime MFGDate { get; set; }

		[Display(Name = "Expiration Date")]
		public DateTime EXPDate { get; set; }

		[Display(Name = "Storage Condition")]
		public string StorageCondition { get; set; }
		public ICollection<AnalyzeDetail> AnalyzeDetails { get; set; }

	}
}
