using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Newtonsoft.Json;
using Restaurant.Web.Models;
using Restaurant.Web.Services.IServices;
using System.Text;

namespace Restaurant.Web.Services
{
    public class CommonService : ICommonService
    {

        private readonly ITokenProvider _tokenProvider;
        private readonly IHttpClientFactory _httpClientFactory;

        public CommonService(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider)
        {
            _httpClientFactory = httpClientFactory;
            _tokenProvider = tokenProvider;
        }



        public async Task<ResponseDTO?> SendAsync(RequestHandler requestHandler, bool withBearer = true)
        {
            try
            {

                var client = _httpClientFactory.CreateClient("RestaurantAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");

                //token
                if (withBearer)
                {
                    var token = _tokenProvider.GetToken();
                    message.Headers.Add("Authorization", $"Bearer {token}");
                }


                message.RequestUri = new Uri(requestHandler.URL);
                client.DefaultRequestHeaders.Clear();
                if (requestHandler.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestHandler.Data),
                        Encoding.UTF8, "application/json");
                }
                HttpResponseMessage apiResponse = null;
                switch (requestHandler.ApiType)
                {
                    case Standard.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case Standard.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case Standard.ApiType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case Standard.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;

                }
                apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDTO = JsonConvert.DeserializeObject<ResponseDTO?>(apiContent);
                return apiResponseDTO;
            }
            catch (Exception ex)
            {
                var dto = new ResponseDTO()
                {
                    DisplayMessage = "Error",
                    Errors = new List<string>()
                    {
                        Convert.ToString(ex.Message)
                    },
                    Success = false

                };
                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDTO = JsonConvert.DeserializeObject<ResponseDTO?>(res);
                return apiResponseDTO;

            }
        }

       }
}
