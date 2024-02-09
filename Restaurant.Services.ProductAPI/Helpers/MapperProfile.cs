using AutoMapper;
using Restaurant.Services.ProductAPI.Models;
using Restaurant.Services.ProductAPI.Models.DTO;

namespace Restaurant.Services.ProductAPI.Helpers
{
    public class MapperProfile : Profile
    {

        public MapperProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            
        }
    }
}
