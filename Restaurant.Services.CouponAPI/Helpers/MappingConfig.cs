using AutoMapper;
using Restaurant.Services.CouponAPI.Model;
using Restaurant.Services.CouponAPI.Model.DTO;

namespace Restaurant.Services.CouponAPI.Helpers
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<CouponDTO, Coupon>();
            CreateMap<Coupon,CouponDTO>();
        }
    }
}
