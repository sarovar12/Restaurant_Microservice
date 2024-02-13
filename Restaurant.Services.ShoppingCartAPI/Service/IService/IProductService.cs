using Restaurant.Services.ShoppingCartAPI.Model.DTO;

namespace Restaurant.Services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
    }
}
