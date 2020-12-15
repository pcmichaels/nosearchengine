using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NoSearchEngine.App.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSearchEngine.App.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {

        private readonly ILogger<SearchController> _logger;

        public SearchController(ILogger<SearchController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Resource> Get()
        {
            return new List<Resource>()
            {
                new Resource()
                {
                    Url = "www.pmichaels.net",
                    Description = "Blog",
                    ResourceType = ResourceType.TopLevelSite
                },
                new Resource()
                {
                    Url = "https://www.pmichaels.net/2020/12/12/sending-a-service-bus-message-failed/",
                    Description = "Azure Service Bus Errror",
                    ResourceType = ResourceType.SpecificUrl
                }
            };
        }
    }
}
