using NoSearchEngine.DataAccess.Entities;
using System.Collections.Generic;

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
