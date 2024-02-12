

using Restaurant.Services.CouponAPI.Model.DTO;

namespace Restaurant.Services.CouponAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDTO> GetCouponByCode(string couponCode);
    }
}
