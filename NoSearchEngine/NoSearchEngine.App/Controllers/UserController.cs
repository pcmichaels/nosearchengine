using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoSearchEngine.Models;
using NoSearchEngine.Service.Interfaces;

namespace NoSearchEngine.App.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet()]
        public User CurrentUser()
        {
            var user = new User()
            {
                SubjectId = _userService.GetSubjectId(User),
                UserRating = _userService.GetSubjectRating(User)
            };

            return user;
        }
    }
}
