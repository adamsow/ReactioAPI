using AutoMapper;
using Reactio.Core.Domain;
using Reactio.Infrastructure.DTO;

namespace Reactio.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Reaction, ReactionDTO>();
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<Substrate, SubstrateDTO>();
            })
            .CreateMapper();
    }
}
