using Newtonsoft.Json.Linq;
using Restaurant.Web.Models;
using Restaurant.Web.Services.IServices;

namespace Restaurant.Web.Services
{
    public class AuthService : CommonService, IAuthServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AuthService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _httpClientFactory = clientFactory;

        }
         public async Task<T> AssignRole<T>(RegistrationRequestDTO registrationRequestDTO)
        {
            return await SendAsync<T>(new RequestHandler()
            {
                ApiType = Standard.ApiType.POST,
                Data = registrationRequestDTO,
                URL = Standard.AuthenticationAPIBase + "/api/auth/assignrole",
            });
        }

       

        public async Task<T> Login<T>(LoginRequestDTO loginRequestDTO)
        {
            return await SendAsync<T>(new RequestHandler()
            {
                ApiType = Standard.ApiType.POST,
                Data = loginRequestDTO,
                URL = Standard.AuthenticationAPIBase + "/api/auth/login",
              });
        }

        public async Task<T> Register<T>(RegistrationRequestDTO registrationRequestDTO)
        {
            return await SendAsync<T>(new RequestHandler()
            {
                ApiType = Standard.ApiType.POST,
                Data = registrationRequestDTO,
                URL = Standard.AuthenticationAPIBase + "/api/auth/register",
                AccessToken = "",
            });
        }
    }
}
