using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoSearchEngine.DataAccess
{
    [Table("ApplicationUser")]
    public class ApplicationUserEntity : IdentityUser
    {
    }
}
