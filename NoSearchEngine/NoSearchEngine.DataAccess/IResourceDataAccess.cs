using NoSearchEngine.DataAccess.Entities;
using NoSearchEngine.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoSearchEngine.DataAccess
{
    public interface IResourceDataAccess
    {
        IEnumerable<ResourceEntity> SearchAll(string searchText);
        Task<bool> AddResource(Resource resource);
    }
}