using Restaurant.Web.Models;

namespace Restaurant.Web.Services.IServices
{
    public interface IProductServices 
    {
        Task<ResponseDTO?> GetAllProducts();
        Task<ResponseDTO?> GetProductById(int id);
        Task<ResponseDTO?> CreateProduct (ProductDTO productDTO);
        Task<ResponseDTO?> UpdateProduct(ProductDTO productDTO);
        Task<ResponseDTO?> DeleteProduct(int id);

    }
}
