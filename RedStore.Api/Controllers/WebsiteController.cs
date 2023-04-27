using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedStore.Api.Interfaces;
using RedStore.Models.Dtos;

namespace RedStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebsiteController : ControllerBase
    {
        private readonly IWebsiteRepository websiteRepository;

        public WebsiteController(IWebsiteRepository websiteRepository)
        {
            this.websiteRepository = websiteRepository;
        }

        //Get Information
        [HttpGet]
        public async Task<ActionResult<InformationDto>> GetInformation()
        {
            try
            {
                var product = await this.websiteRepository.GetInformation();

                if (product == null)
                {
                    return BadRequest();
                }
                else
                {
                    //var productCategory = await this.productRepository.GetCategory(product.CategoryId);
                    return Ok(product);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");

            }
        }

    }
}
