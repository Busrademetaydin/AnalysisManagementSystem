using Analysis.Entities.Concrete;
using AnalysisManagement.WebMVC.Models;
using AutoMapper;

namespace AnalysisManagement.WebMVC.AutoMapperProfile
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<DrugInsertVM, Drug>().ReverseMap();
            CreateMap<DrugUpdateVM, Drug>().ReverseMap();
            CreateMap<HPLCEquipmentInsertVM, HPLCEquipment>().ReverseMap();
            CreateMap<HPLCEquipmentUpdateVM, HPLCEquipment>().ReverseMap();
        }
    }
}
