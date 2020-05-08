using System;
using System.Collections.Generic;
using System.Text;

namespace NoSearchEngine.DataAccess
{
    public interface IUserRepository
    {
        int GetUserRating(string subjectId);
    }
}
