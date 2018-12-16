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
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<Substrate, SubstrateDTO>();
                cfg.CreateMap<AppSetting, AppSettingDTO>();
            })
            .CreateMapper();
    }
}
