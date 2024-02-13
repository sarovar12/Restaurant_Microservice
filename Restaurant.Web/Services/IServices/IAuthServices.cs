using Restaurant.Web.Models;

namespace Restaurant.Web.Services.IServices
{
    public interface IAuthServices
    {
        Task<ResponseDTO?> Login (LoginRequestDTO loginRequestDTO);
        Task<ResponseDTO?> Register (RegistrationRequestDTO registrationRequestDTO);
        Task<ResponseDTO?> AssignRole (RegistrationRequestDTO registrationRequestDTO);

    }
}
