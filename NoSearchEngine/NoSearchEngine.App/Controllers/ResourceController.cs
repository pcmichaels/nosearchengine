using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NoSearchEngine.Models;
using NoSearchEngine.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

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
        private readonly IApprovalService _approvalService;
        private readonly IUserService _userService;

        public ResourceController(ILogger<ResourceController> logger,
            ISearchService searchService, IAddResourceService addResourceService,
            IApprovalService approvalService, IUserService userService)
        {
            _logger = logger;
            _searchService = searchService;
            _addResourceService = addResourceService;
            _approvalService = approvalService;
            _userService = userService;
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

        [HttpGet()]
        public IEnumerable<Resource> ApprovalList() =>
            _approvalService.GetApprovalSiteList();

        [HttpPost("{id}")]
        public async Task<IActionResult> ApproveResource(string id)
        {
            string subjectId = _userService.GetSubjectId(User);
            var result = await _approvalService.ApproveResource(id);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Errors.FirstOrDefault() ?? "Unknown");
        }

        [HttpPost]
        public async Task<IActionResult> AddResource([FromBody]Resource resource)
        {
            string subjectId = _userService.GetSubjectId(User);
            var result = await _addResourceService.AddResource(resource, subjectId);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Errors.FirstOrDefault() ?? "Unknown");
        }
    }
}
