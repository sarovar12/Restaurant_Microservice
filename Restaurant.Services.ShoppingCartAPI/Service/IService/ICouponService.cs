using Restaurant.Services.ShoppingCartAPI.Model.DTO;

namespace Restaurant.Services.ShoppingCartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDTO> GetCoupon(string coupon);
    }
}
