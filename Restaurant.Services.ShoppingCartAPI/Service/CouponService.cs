using Newtonsoft.Json;
using Restaurant.Services.ShoppingCartAPI.Model.DTO;
using Restaurant.Services.ShoppingCartAPI.Service.IService;

namespace Restaurant.Services.ShoppingCartAPI.Service
{
    public class CouponService : ICouponService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CouponService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<CouponDTO> GetCoupon(string coupon)
        {
            var client = _httpClientFactory.CreateClient("Coupon");
            var response = await client.GetAsync($"/api/coupon/getByCode/{coupon}");
            var apiContent = await response.Content.ReadAsStringAsync();
            var responseContent = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
            if (responseContent.Success)
            {
                return JsonConvert.DeserializeObject<CouponDTO>(Convert.ToString(responseContent.Result));
            }
            return new CouponDTO();

        }
    }
}
