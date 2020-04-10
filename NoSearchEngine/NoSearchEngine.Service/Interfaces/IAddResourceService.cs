using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoSearchEngine.Service.Interfaces
{
    public interface IAddResourceService
    {
        bool AddResource(Resource resource);
    }
}
