using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NoSearchEngine.Models;
using NoSearchEngine.Service.Interfaces;

namespace NoSearchEngine.App.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ResourceController : ControllerBase
    {

        private readonly ILogger<ResourceController> _logger;
        private readonly ISearchService _searchService;

        public ResourceController(ILogger<ResourceController> logger,
            ISearchService searchService)
        {
            _logger = logger;
            _searchService = searchService;
        }

        [HttpGet("{searchText}")]
        public IEnumerable<Resource> Search(string searchText)
        {
            var results = _searchService.SearchAll(searchText);
            return results;
        }

        [HttpPost]
        public IActionResult AddResource([FromBody]Resource resource)
        {
            return Ok();
        }
    }
}
