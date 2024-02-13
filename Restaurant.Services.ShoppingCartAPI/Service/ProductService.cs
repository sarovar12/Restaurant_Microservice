using Newtonsoft.Json;
using Restaurant.Services.ShoppingCartAPI.Model.DTO;
using Restaurant.Services.ShoppingCartAPI.Service.IService;

namespace Restaurant.Services.ShoppingCartAPI.Service
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var client = _httpClientFactory.CreateClient("Products");
            var response = await client.GetAsync($"/api/products");
            var apiContent = await response.Content.ReadAsStringAsync();
            var responseContent = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
            if (responseContent.Success)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(Convert.ToString(responseContent.Result));
            }
            return new List<ProductDTO>();  
        }
    }
}
