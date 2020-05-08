using NoSearchEngine.DataAccess;
using NoSearchEngine.Models;
using NoSearchEngine.Service.Interfaces;
using System.Collections.Generic;

namespace NoSearchEngine.Service
{
    public class SearchService : ISearchService
    {
        private readonly IResourceRepository _resourceDataAccess;

        public SearchService(IResourceRepository resourceDataAccess)
        {
            _resourceDataAccess = resourceDataAccess;
        }

        public IEnumerable<Resource> ByUser(string subjectId) =>        
            _resourceDataAccess.ByUser(subjectId);        

        public IEnumerable<Resource> SearchAll(string searchText) =>
            _resourceDataAccess.SearchAll(searchText);
    }
}
