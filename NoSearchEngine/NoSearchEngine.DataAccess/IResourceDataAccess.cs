using NoSearchEngine.DataAccess.Entities;
using System.Collections.Generic;

namespace NoSearchEngine.DataAccess
{
    public interface IResourceDataAccess
    {
        IEnumerable<ResourceEntity> SearchAll(string searchText);
    }
}