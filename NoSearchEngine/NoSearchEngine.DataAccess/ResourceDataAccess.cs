using NoSearchEngine.DataAccess.Entities;
using NoSearchEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSearchEngine.DataAccess
{
    public class ResourceDataAccess : IResourceDataAccess
    {
        private readonly NoSearchDbContext _noSearchDbContext;

        public ResourceDataAccess(NoSearchDbContext noSearchDbContext)
        {
            _noSearchDbContext = noSearchDbContext;
        }

        public async Task<bool> AddResource(Resource resource)
        {
            var resourceEntity = ResourceEntity.FromModel(resource);
            _noSearchDbContext.ResourceEntities.Add(resourceEntity);
            int saveChangesResult = await _noSearchDbContext.SaveChangesAsync();
            return (saveChangesResult != 0);
        }

        public IEnumerable<ResourceEntity> SearchAll(string searchText)
        {
            // Search Url first
            var urlResults = _noSearchDbContext.ResourceEntities
                .Where(a => a.Url == searchText);

            if (urlResults.Any())
            {
                return urlResults;
            }

            // Search Description if no Url results found
            var descriptionResults = _noSearchDbContext.ResourceEntities
                .Where(a => a.Description == searchText);

            if (descriptionResults.Any())
            {
                return descriptionResults;
            }

            return null;
        }
    }
}
