using RedStore.Models.Dtos;

namespace RedStore.Web.Interfaces
{
    public interface IWebsiteService
    {
        //Get Information
        Task<InformationDto> GetInformation();
    }
}
