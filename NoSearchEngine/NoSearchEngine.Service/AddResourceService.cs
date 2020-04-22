using NoSearchEngine.DataAccess;
using NoSearchEngine.Models;
using NoSearchEngine.Service.Interfaces;
using System.Threading.Tasks;

namespace NoSearchEngine.Service
{
    public class AddResourceService : IAddResourceService
    {
        private readonly IResourceDataAccess _resourceDataAccess;

        public AddResourceService(IResourceDataAccess resourceDataAccess)
        {
            _resourceDataAccess = resourceDataAccess;
        }

        public async Task<bool> AddResource(Resource resource)
        {
            // Tidy / Sanitise input

            // Add to DB
            return await _resourceDataAccess.AddResource(resource);
        }
    }
}
