using Restaurant.Services.Authentication.Models.DTO;

namespace Restaurant.Services.Authentication.Service
{
    public interface IAuthService
    {
        Task<string> Register (RegistrationRequestDTO registrationRequestDTO);
        Task<LoginResponseDTO> Login (LoginRequestDTO loginRequestDTO);
        Task<bool> AssignRole(string email, string roleName);

    }
}
