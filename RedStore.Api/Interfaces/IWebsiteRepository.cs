using RedStore.Api.Entities;

namespace RedStore.Api.Interfaces
{
    public interface IWebsiteRepository
    {
        //Get Information
        Task<Information> GetInformation();
    }
}