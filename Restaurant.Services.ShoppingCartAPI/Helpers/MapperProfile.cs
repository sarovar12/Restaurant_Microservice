using AutoMapper;
using Restaurant.Services.ShoppingCartAPI.Model;
using Restaurant.Services.ShoppingCartAPI.Model.DTO;

namespace Restaurant.Services.ProductAPI.Helpers
{
    public class MapperProfile : Profile
    {

        public MapperProfile()
        {
            CreateMap<CartHeader, CartHeaderDTO>().ReverseMap();
            CreateMap<CartDetails, CartDetailDTO>().ReverseMap();
            
        }
    }
}
