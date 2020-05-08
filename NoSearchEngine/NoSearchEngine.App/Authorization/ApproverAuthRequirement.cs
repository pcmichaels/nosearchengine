using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSearchEngine.App.Authorization
{
    public class ApproverAuthRequirement : IAuthorizationRequirement
    {
        public int UserRating { get; set; }

        public ApproverAuthRequirement(int userRating)
        {
            UserRating = userRating;
        }
    }
}
