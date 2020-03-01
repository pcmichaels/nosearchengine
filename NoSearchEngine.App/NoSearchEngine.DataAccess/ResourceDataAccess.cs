using NoSearchEngine.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace NoSearchEngine.DataAccess
{
    public class ResourceDataAccess : IResourceDataAccess
    {
        public IEnumerable<ResourceEntity> SearchAll(string searchText)
        {
            return new List<ResourceEntity>() 
            { 
                new ResourceEntity()
                {
                    Url = "www.test.com",
                    Description = "test desc"
                }
            };
        }
    }
}
