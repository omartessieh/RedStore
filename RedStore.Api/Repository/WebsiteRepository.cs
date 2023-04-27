using Microsoft.EntityFrameworkCore;
using RedStore.Api.Data;
using RedStore.Api.Entities;
using RedStore.Api.Interfaces;
using RedStore.Models.Dtos;

namespace RedStore.Api.Repository
{
    public class WebsiteRepository : IWebsiteRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public WebsiteRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        //Get Information
        public async Task<Information> GetInformation()
        {
            var product = await applicationDbContext.Informations.FirstOrDefaultAsync();
            return product;
        }

    }
}