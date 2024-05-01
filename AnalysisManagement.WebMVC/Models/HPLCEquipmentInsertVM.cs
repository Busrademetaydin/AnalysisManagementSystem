using System.ComponentModel.DataAnnotations;

namespace AnalysisManagement.WebMVC.Models
{
    public class HPLCEquipmentInsertVM
    {
        //public int EquipmentId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ekipman markası boş bırakılamaz")]
        public string Brand { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ekipmanın seri no.su boş bırakılamaz")]
        public string SerialNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ekipmanın kalibrasyon geçerlilik tarihi boş bırakılamaz")]
        public DateTime CalibrationDueDate { get; set; }

    }

}
