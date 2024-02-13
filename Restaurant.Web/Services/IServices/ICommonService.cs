using Restaurant.Web.Models;

namespace Restaurant.Web.Services.IServices
{
    public interface ICommonService
    {
        Task<ResponseDTO?> SendAsync(RequestHandler requestHandler, bool withBearer = true);
    }
}
