using NoSearchEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoSearchEngine.Service.Interfaces
{
    public interface ISearchService
    {
        IEnumerable<Resource> SearchAll(string searchText);
    }
}
