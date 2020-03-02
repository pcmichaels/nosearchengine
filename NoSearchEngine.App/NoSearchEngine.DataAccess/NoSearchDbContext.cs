using Microsoft.EntityFrameworkCore;
using NoSearchEngine.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoSearchEngine.DataAccess
{
    public class NoSearchDbContext : DbContext
    {
        public NoSearchDbContext(DbContextOptions<NoSearchDbContext> options)
            : base(options)
        {

        }

        public DbSet<ResourceEntity> ResourceEntities { get; set; }
    }
}
