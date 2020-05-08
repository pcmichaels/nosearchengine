using Microsoft.AspNetCore.Authorization;
using NoSearchEngine.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NoSearchEngine.App.Authorization
{
    public class ApproverAuthHandler : AuthorizationHandler<ApproverAuthRequirement>
    {
        private readonly IUserService _userService;

        public ApproverAuthHandler(IUserService userService)
        {
            _userService = userService;
        }        

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            ApproverAuthRequirement requirement)
        {
            int? userRating = _userService.GetSubjectRating(context.User);            
            if (!userRating.HasValue)
            {
                return Task.CompletedTask;
            }

            if (userRating >= requirement.UserRating)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
