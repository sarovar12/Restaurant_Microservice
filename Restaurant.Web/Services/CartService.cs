using Restaurant.Web.Models;
using Restaurant.Web.Services.IServices;

namespace Restaurant.Web.Services
{
    public class CartService : ICartService
    {
        private readonly ICommonService _commonService;
        public CartService(ICommonService commonService)
        {
            _commonService = commonService;
        }
        public async Task<ResponseDTO?> ApplyCouponAsync(CartDTO cartDto)
        {
            return await _commonService.SendAsync(new RequestHandler()
            {
                ApiType = Standard.ApiType.POST,
                Data = cartDto,
                URL = Standard.ShoppingCartAPIBase + "/api/cart/ApplyCoupon"
            });
        }

        public async Task<ResponseDTO?> EmailCart(CartDTO cartDto)
        {
            return await _commonService.SendAsync(new RequestHandler()
            {
                ApiType = Standard.ApiType.POST,
                Data = cartDto,
                URL = Standard.ShoppingCartAPIBase + "/api/cart/EmailCartRequest"
            });
        }

        public async Task<ResponseDTO?> GetCartByUserIdAsnyc(string userId)
        {
            return await _commonService.SendAsync(new RequestHandler()
            {
                ApiType = Standard.ApiType.POST,
                URL = Standard.ShoppingCartAPIBase + "/api/cart/GetCart/"+userId
            });
        }

        public async Task<ResponseDTO?> RemoveFromCartAsync(int cartDetailsId)
        {
            return await _commonService.SendAsync(new RequestHandler()
            {
                ApiType = Standard.ApiType.POST,
                URL = Standard.ShoppingCartAPIBase + "/api/cart/RemoveCart"
            });
        }

        public async Task<ResponseDTO?> UpsertCartAsync(CartDTO cartDto)
        {
            return await _commonService.SendAsync(new RequestHandler()
            {
                ApiType = Standard.ApiType.POST,
                Data = cartDto,
                URL = Standard.ShoppingCartAPIBase + "/api/cart/CartUpsert"
            });
        }
    }
}
