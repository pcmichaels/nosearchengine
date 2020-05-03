using IdentityServer4.Extensions;
using NoSearchEngine.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace NoSearchEngine.Service
{
    public class UserService : IUserService
    {
        public string GetSubjectId(IPrincipal principal) =>        
            principal.Identity.GetSubjectId();
    }
}
