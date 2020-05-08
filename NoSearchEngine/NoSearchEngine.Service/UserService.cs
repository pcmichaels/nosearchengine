using IdentityServer4.Extensions;
using NoSearchEngine.DataAccess;
using NoSearchEngine.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace NoSearchEngine.Service
{
    public class UserService : IUserService
    {        
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {            
            _userRepository = userRepository;
        }

        public string GetSubjectId(IPrincipal principal) =>        
            principal.Identity.GetSubjectId();

        public int? GetSubjectRating(IPrincipal principal)
        {
            var subjectId = GetSubjectId(principal);
            return _userRepository.GetUserRating(subjectId);
        }
    }
}
