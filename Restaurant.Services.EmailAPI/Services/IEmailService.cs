using Restaurant.Services.EmailAPI.Model.DTO;

namespace Restaurant.Services.EmailAPI.Services
{
    public interface IEmailService
    {
        Task EmailCartAndLog(CartDTO cartDTO);
    }
}
