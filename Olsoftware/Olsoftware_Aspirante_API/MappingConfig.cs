using AutoMapper;
using Olsoftware_Aspirante_API.Modelos;
using Olsoftware_Aspirante_API.Modelos.Dto;

namespace Olsoftware_Aspirante_API
{
    public class MappingConfig: Profile
    {
        public MappingConfig() 
        {
            CreateMap<Aspirante, AspiranteDto>().ReverseMap();
        }
    }
}
