using Restaurant.Web.Models;

namespace Restaurant.Web.Services.IServices
{
    public interface ICouponService
    {
        Task<ResponseDTO?> GetCoupon(string couponCode, string token = null);

    }
}
