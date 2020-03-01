using NoSearchEngine.DataAccess;
using NoSearchEngine.Models;
using NoSearchEngine.Service.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NoSearchEngine.Service
{
    public class SearchService : ISearchService
    {
        private readonly ResourceDataAccess _resourceDataAccess;

        public SearchService(ResourceDataAccess resourceDataAccess)
        {
            _resourceDataAccess = resourceDataAccess;
        }

        public IEnumerable<Resource> SearchAll(string searchText) =>
            _resourceDataAccess.SearchAll(searchText);
    }
}
