using Restaurant.Web.Models;

namespace Restaurant.Web.Services.IServices
{
    public interface IAuthServices
    {
        Task<T> Login<T> (LoginRequestDTO loginRequestDTO);
        Task<T> Register<T> (RegistrationRequestDTO registrationRequestDTO);
        Task<T> AssignRole<T> (RegistrationRequestDTO registrationRequestDTO);

    }
}
