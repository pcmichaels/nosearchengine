using NoSearchEngine.Models;
using System.Collections.Generic;

namespace NoSearchEngine.Service.Interfaces
{
    public interface ISearchService
    {
        IEnumerable<Resource> SearchAll(string searchText);
    }
}
