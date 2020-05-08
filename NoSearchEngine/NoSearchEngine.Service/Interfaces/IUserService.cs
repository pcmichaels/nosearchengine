using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace NoSearchEngine.Service.Interfaces
{
    public interface IUserService
    {
        string GetSubjectId(IPrincipal principal);
        int? GetSubjectRating(IPrincipal principal);
    }
}
