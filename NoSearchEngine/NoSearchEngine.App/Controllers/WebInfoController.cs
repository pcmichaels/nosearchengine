using Microsoft.AspNetCore.Mvc;
using NoSearchEngine.Service.Interfaces;
using System.Threading.Tasks;

namespace NoSearchEngine.App.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WebInfoController : ControllerBase
    {
        private readonly IWebSiteService _webSiteService;

        public WebInfoController(IWebSiteService webSiteService)
        {
            _webSiteService = webSiteService;
        }

        [HttpGet("{url}")]
        public async Task<IActionResult> Site(string url)
        {
            var result = await _webSiteService.GetSiteMetaData(url);

            if (!result.IsSuccess)
            {
                // TODO: What to do here?
                return BadRequest();
            }

            return Ok(result.Data);
        }
    }
}
