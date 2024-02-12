using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Newtonsoft.Json;
using Restaurant.Web.Models;
using Restaurant.Web.Services.IServices;
using System.ComponentModel;
using System.Text;

namespace Restaurant.Web.Services
{
    public class CommonService : ICommonService
    {
        public ResponseDTO responseModel { get; set; }
        public IHttpClientFactory httpClientFactory { get; set; }
        public CommonService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
            responseModel = new ResponseDTO();
        }



        public async Task<T> SendAsync<T>(RequestHandler requestHandler)
        {
            try
            {

                var client = httpClientFactory.CreateClient("RestaurantAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
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
                var apiResponseDTO = JsonConvert.DeserializeObject<T>(apiContent);
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
                var apiResponseDTO = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDTO;

            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
