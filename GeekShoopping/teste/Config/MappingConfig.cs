using AutoMapper;
using GeekShopping.CartAPI.Model;
using GeekShopping.teste.Data.ValueObjects;

namespace GeekShopping.teste.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<ProductVO, Product>().ReverseMap();
                config.CreateMap<CartHeaderVO, CartHeader>().ReverseMap();
                config.CreateMap<CartDetailVO, CartDetail>().ReverseMap();
                config.CreateMap<CartVO, CartVO>().ReverseMap();
               
            });
            return mappingConfig;
        }
    }
}
