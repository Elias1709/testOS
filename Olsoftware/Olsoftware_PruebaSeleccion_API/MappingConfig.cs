using AutoMapper;
using Olsoftware_PruebaSeleccion_API.Modelos;
using Olsoftware_PruebaSeleccion_API.Modelos.Dto;

namespace Olsoftware_PruebaSeleccion_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<PruebaSeleccion, PruebaSeleccionDto>().ReverseMap();
        }
    }
}
