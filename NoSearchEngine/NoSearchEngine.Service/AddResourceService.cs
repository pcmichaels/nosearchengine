﻿using NoSearchEngine.DataAccess;
using NoSearchEngine.Models;
using NoSearchEngine.Service.Interfaces;
using System.Threading.Tasks;
using WebSiteMeta.Scraper;

namespace NoSearchEngine.Service
{
    public class AddResourceService : IAddResourceService
    {
        private readonly IResourceDataAccess _resourceDataAccess;
        private readonly IFindMetaData _findMetaData;

        public AddResourceService(IResourceDataAccess resourceDataAccess,
            IFindMetaData findMetaData)
        {
            _resourceDataAccess = resourceDataAccess;
            _findMetaData = findMetaData;
        }

        public async Task<DataResult<Resource>> AddResource(Resource resource, string requestor)
        {
            // Tidy / Sanitise input
            resource.Url = _findMetaData.CleanUrl(resource.Url);
            if (!_findMetaData.ValidateUrl(resource.Url))
            {
                return DataResult<Resource>.Error("Invalid Url");
            }

            // Add to DB
            return await _resourceDataAccess.AddResource(resource, requestor);
        }
    }
}
