﻿using NoSearchEngine.DataAccess.Entities;
using NoSearchEngine.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoSearchEngine.DataAccess
{
    public interface IResourceDataAccess
    {
        IEnumerable<ResourceEntity> SearchAll(string searchText);
        Task<DataResult<Resource>> AddResource(Resource resource, string requestor);
        IEnumerable<Resource> ByUser(string subjectId);
        Resource ByUrl(string url);
    }
}