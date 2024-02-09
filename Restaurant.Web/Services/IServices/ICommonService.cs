using Restaurant.Web.Models;

namespace Restaurant.Web.Services.IServices
{
    public interface ICommonService : IDisposable
    {
        ResponseDTO responseModel { get; set; }
        Task<T> SendAsync<T>(RequestHandler requestHandler);
    }
}
