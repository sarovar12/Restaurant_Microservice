using Restaurant.Web.Models;
using Restaurant.Web.Services.IServices;

namespace Restaurant.Web.Services
{
    public class AuthService : IAuthServices
    {
        private readonly ICommonService _commonService;
        public AuthService( ICommonService commonService) 
        {
            _commonService = commonService;

        }
         public async Task<ResponseDTO?> AssignRole(RegistrationRequestDTO registrationRequestDTO)
        {
            return await _commonService.SendAsync(new RequestHandler()
            {
                ApiType = Standard.ApiType.POST,
                Data = registrationRequestDTO,
                URL = Standard.AuthenticationAPIBase + "/api/auth/assignrole",
            });
        }


        public async Task<ResponseDTO?> Login(LoginRequestDTO loginRequestDTO)
        {
            return await _commonService.SendAsync(new RequestHandler()
            {
                ApiType = Standard.ApiType.POST,
                Data = loginRequestDTO,
                URL = Standard.AuthenticationAPIBase + "/api/auth/login",
              });
        }

        public async Task<ResponseDTO?> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            return await _commonService.SendAsync(new RequestHandler()
            {
                ApiType = Standard.ApiType.POST,
                Data = registrationRequestDTO,
                URL = Standard.AuthenticationAPIBase + "/api/auth/register",
            });
        }
    }
}
