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
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {

        private readonly ILogger<SearchController> _logger;
        private readonly ISearchService _searchService;

        public SearchController(ILogger<SearchController> logger,
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
    }
}
