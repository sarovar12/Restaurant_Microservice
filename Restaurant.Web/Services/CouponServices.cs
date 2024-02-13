using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Restaurant.Web.Models;
using Restaurant.Web.Services.IServices;

namespace Restaurant.Web.Services
{
    public class CouponServices : ICouponService
    {
        private readonly ICommonService _commonService;


        public CouponServices(ICommonService commonService) 
        {
            _commonService = commonService;
        }

        public async Task<ResponseDTO?> GetCoupon(string couponCode, string token = null)
        {
            return await _commonService.SendAsync(new RequestHandler()
            {
                ApiType = Standard.ApiType.GET,
                URL = Standard.CouponAPIBase + "/api/getbycode/" + couponCode,
                AccessToken = token
            });
        }

      
    }
}
