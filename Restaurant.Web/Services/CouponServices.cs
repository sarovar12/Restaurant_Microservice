using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Restaurant.Web.Models;
using Restaurant.Web.Services.IServices;

namespace Restaurant.Web.Services
{
    public class CouponServices : CommonService, ICouponService
    {
        private readonly IHttpClientFactory _httpClientFactory;


        public CouponServices(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _httpClientFactory = clientFactory;
        }

        public async Task<T> GetCoupon<T>(string couponCode, string token = null)
        {
            return await this.SendAsync<T>(new RequestHandler()
            {
                ApiType = Standard.ApiType.GET,
                URL = Standard.CouponAPIBase + "/api/getbycode/" + couponCode,
                AccessToken = token
            });
        }

      
    }
}
