using AutoMapper;
using Newtonsoft.Json;
using ReactioAPI.Core.Domain;
using ReactioAPI.Infrastructure.DTO;
using System.Collections.Generic;

namespace ReactioAPI.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Reaction, ReactionDTO>()
                    .ForMember(dest => dest.Factors, opt => opt.MapFrom(src => 
                !string.IsNullOrWhiteSpace(src.Factor) ? 
                JsonConvert.DeserializeObject<IEnumerable<Factor>>(src.Factor) : null));
                cfg.CreateMap<Product, ProductDTO>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Reagent.Name))
                    .ForMember(dest => dest.NamePL, opt => opt.MapFrom(src => src.Reagent.NamePL))
                    .ForMember(dest => dest.Pattern, opt => opt.MapFrom(src => src.Reagent.Pattern));
                cfg.CreateMap<Substrate, SubstrateDTO>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Reagent.Name))
                    .ForMember(dest => dest.NamePL, opt => opt.MapFrom(src => src.Reagent.NamePL))
                    .ForMember(dest => dest.Pattern, opt => opt.MapFrom(src => src.Reagent.Pattern));
                cfg.CreateMap<AppSetting, AppSettingDTO>();
            })
            .CreateMapper();
    }
}
