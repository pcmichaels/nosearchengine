using System;
using System.Collections.Generic;
using System.Text;

namespace NoSearchEngine.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly NoSearchDbContext _noSearchDbContext;

        public UserRepository(NoSearchDbContext noSearchDbContext)
        {
            _noSearchDbContext = noSearchDbContext;
        }

        public int GetUserRating(string subjectId)
        {
            var user = _noSearchDbContext.Users.Find(subjectId);            
            return user.UserRating;
        }
    }
}
