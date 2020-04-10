using NoSearchEngine.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoSearchEngine.UnitTests.Data
{
    public static class SearchResults
    {
        public static List<ResourceEntity> GetSingleSearchResult(string description) =>
            new List<ResourceEntity>()
            {
                new ResourceEntity() { Url = "www.test.com", Description = description }
            };
    }
}
