using Restaurant.Web.Models;
using Restaurant.Web.Services.IServices;

namespace Restaurant.Web.Services
{
    public class ProductService :  IProductServices
    {
        private readonly ICommonService _commonService;
        public ProductService(ICommonService commonService) 
        {
            _commonService = commonService;

        }
        public async Task<ResponseDTO?> CreateProduct(ProductDTO productDTO)
        {
            return await _commonService.SendAsync(new RequestHandler()
            {
                ApiType = Standard.ApiType.POST,
                Data = productDTO,
                URL = Standard.ProductAPIBase + "/api/products",
            });
        }

        public async Task<ResponseDTO?> DeleteProduct(int id)
        {
            return await _commonService.SendAsync(new RequestHandler()
            {
                ApiType = Standard.ApiType.DELETE,
                URL = Standard.ProductAPIBase + "/api/products/" + id,
            });
        }

        public async Task<ResponseDTO?> GetAllProducts()
        {
            return await _commonService.SendAsync(new RequestHandler()
            {
                ApiType = Standard.ApiType.GET,
                URL = Standard.ProductAPIBase + "/api/products",
            });
        }

        public async Task<ResponseDTO?> GetProductById(int id)
        {
            return await _commonService.SendAsync(new RequestHandler()
            {
                ApiType = Standard.ApiType.GET,
                URL = Standard.ProductAPIBase + "/api/products/" + id,
            });

        }

        public async Task<ResponseDTO?> UpdateProduct(ProductDTO productDTO)
        {
            return await _commonService.SendAsync(new RequestHandler()
            {
                ApiType = Standard.ApiType.PUT,
                URL = Standard.ProductAPIBase + "/api/products",
                Data = productDTO
            });
        }
    }
}
