using Microsoft.AspNetCore.Mvc;
using Restaurant.Services.CouponAPI.Model.DTO;
using Restaurant.Services.CouponAPI.Repository;

namespace Restaurant.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    public class CouponController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;
        protected ResponseDTO _response;

        public CouponController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
            this._response = new ResponseDTO();

        }
        [HttpGet]
        [Route("GetByCode/{code}")]
        public async Task<object> GetDiscountByCode(string code)
        {
            try
            {
                var coupon = await _couponRepository.GetCouponByCode(code);
                _response.Result = coupon;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.ErrorMessages = new List<string>() {
                ex.ToString()};
            }
            return _response;
        }
    }
}
