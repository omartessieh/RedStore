using RedStore.Models.Dtos;
using RedStore.Web.Interfaces;
using System.Net.Http.Json;

namespace RedStore.Web.Services
{
    public class WebsiteService : IWebsiteService
    {
        private readonly HttpClient httpClient;

        public WebsiteService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        //Get Information
        public async Task<InformationDto> GetInformation()
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Website");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(InformationDto);
                    }
                    return await response.Content.ReadFromJsonAsync<InformationDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

    }
}
