using System.ComponentModel.DataAnnotations;

namespace AnalysisManagement.WebMVC.Models
{
    public class HPLCEquipmentInsertVM
    {
        public int EquipmentId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ekipman markası boş bırakılamaz")]
        public int Brand { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ekipmanın seri no.su boş bırakılamaz")]
        public int SerialNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ekipmanın kalibrasyon geçerlilik tarihi boş bırakılamaz")]
        public int CalibrationDueDate { get; set; }

    }

}
