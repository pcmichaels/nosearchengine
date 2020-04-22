using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NoSearchEngine.DataAccess.Entities;

namespace NoSearchEngine.DataAccess
{
    public class NoSearchDbContext : ApiAuthorizationDbContext<ApplicationUserEntity>
    {
        public NoSearchDbContext(
            DbContextOptions<NoSearchDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }

        public DbSet<ResourceEntity> ResourceEntities { get; set; }
    }
}
