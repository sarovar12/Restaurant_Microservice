using Restaurant.Web.Models;

namespace Restaurant.Web.Services.IServices
{
    public class ProductService : CommonService, IProductServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _httpClientFactory = clientFactory;
            
        }
        public async Task<T> CreateProduct<T>(ProductDTO productDTO)
        {
           return await this.SendAsync<T>(new RequestHandler()
            {
                ApiType = Standard.ApiType.POST,
                Data = productDTO,
                URL = Standard.ProductAPIBase + "/api/products",
                AccessToken = "",
            });
        }

        public async Task<T> DeleteProduct<T>(int id)
        {
            return await this.SendAsync<T>(new RequestHandler()
            {
                ApiType = Standard.ApiType.DELETE,
                URL = Standard.ProductAPIBase + "/api/products/" +id,
                AccessToken = "",
            });
        }

        public async Task<T> GetAllProducts<T>()
        {
            return await this.SendAsync<T>(new RequestHandler()
            {
                ApiType = Standard.ApiType.GET,
                URL = Standard.ProductAPIBase + "/api/products",
                AccessToken = "",
            });
        }

        public async Task<T> GetProductById<T>(int id)
        {
            return await this.SendAsync<T>(new RequestHandler()
            {
                ApiType = Standard.ApiType.GET,
                URL = Standard.ProductAPIBase + "/api/products/" +id,
                AccessToken = "",
            });
            
        }

        public async Task<T> UpdateProduct<T>(ProductDTO productDTO)
        {
            return await this.SendAsync<T>(new RequestHandler()
            {
                ApiType = Standard.ApiType.PUT,
                URL = Standard.ProductAPIBase + "/api/products",
                Data = productDTO,
                AccessToken = "",
            });
        }
    }
}
