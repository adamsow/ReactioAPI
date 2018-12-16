using AutoMapper;
using ReactioAPI.Core.Domain;
using ReactioAPI.Infrastructure.DTO;

namespace ReactioAPI.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Reaction, ReactionDTO>();
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<Substrate, SubstrateDTO>();
                cfg.CreateMap<AppSetting, AppSettingDTO>();
            })
            .CreateMapper();
    }
}
