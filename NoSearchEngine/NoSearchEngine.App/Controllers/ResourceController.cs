using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NoSearchEngine.Models;
using NoSearchEngine.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace NoSearchEngine.App.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class ResourceController : ControllerBase
    {
        private readonly ILogger<ResourceController> _logger;
        private readonly ISearchService _searchService;
        private readonly IAddResourceService _addResourceService;

        public ResourceController(ILogger<ResourceController> logger,
            ISearchService searchService, IAddResourceService addResourceService)
        {
            _logger = logger;
            _searchService = searchService;
            _addResourceService = addResourceService;
        }

        [HttpGet("{searchText}")]
        public IEnumerable<Resource> Search(string searchText)
        {
            var results = _searchService.SearchAll(searchText);
            return results;
        }

        [HttpGet()]
        public IEnumerable<Resource> MySites()
        {
            string subjectId = User.Identity.GetSubjectId();
            var results = _searchService.ByUser(subjectId);
            return results;
        }

        [HttpPost]
        public async Task<IActionResult> AddResource([FromBody]Resource resource)
        {
            string subjectId = User.Identity.GetSubjectId();
            bool result = await _addResourceService.AddResource(resource, subjectId);

            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
