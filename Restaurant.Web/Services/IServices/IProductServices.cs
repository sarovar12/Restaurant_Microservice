using Restaurant.Web.Models;

namespace Restaurant.Web.Services.IServices
{
    public interface IProductServices :ICommonService
    {
        Task<T> GetAllProducts<T>();
        Task<T> GetProductById<T>(int id);
        Task<T> CreateProduct <T>(ProductDTO productDTO);
        Task<T> UpdateProduct<T>(ProductDTO productDTO);
        Task<T> DeleteProduct<T>(int id);

    }
}
