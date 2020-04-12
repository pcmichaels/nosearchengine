using NoSearchEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NoSearchEngine.Service.Interfaces
{
    public interface IAddResourceService
    {
        Task<bool> AddResource(Resource resource);
    }
}
