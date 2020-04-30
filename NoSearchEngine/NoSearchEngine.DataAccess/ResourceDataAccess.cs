﻿using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.EntityFrameworkCore;
using NoSearchEngine.DataAccess.Entities;
using NoSearchEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSearchEngine.DataAccess
{
    public class ResourceDataAccess : IResourceDataAccess
    {
        private readonly NoSearchDbContext _noSearchDbContext;

        public ResourceDataAccess(NoSearchDbContext noSearchDbContext)
        {
            _noSearchDbContext = noSearchDbContext;
        }

        public async Task<DataResult<Resource>> AddResource(Resource resource, string requestor)
        {
            var result = ByUrl(resource.Url);
            if (result != null)
            {
                return DataResult<Resource>.Error(result, "Site already exists");
            }

            var resourceEntity = ResourceEntity.FromModel(resource);

            _noSearchDbContext.ResourceEntities.Add(resourceEntity);
            if (!AddResourceToUser(resourceEntity, requestor))
            {
                return DataResult<Resource>.Error("Error adding the resource");
            }

            int saveChangesResult = await _noSearchDbContext.SaveChangesAsync();
            if (saveChangesResult == 0)
            {
                return DataResult<Resource>.Error("No changes made");
            }
            else
            {
                return DataResult<Resource>.Success(resourceEntity);
            }
        }

        public Resource ByUrl(string url) =>        
            _noSearchDbContext.ResourceEntities.FirstOrDefault(a => a.Url == url);
        
        private bool AddResourceToUser(ResourceEntity resource, string subjectId)
        {
            bool exists = _noSearchDbContext.ResourceUserEntities
                .Any(a => a.Resource.Id == resource.Id
                && a.User.Id == subjectId);

            if (exists) return false;
            var user = _noSearchDbContext.Users.Find(subjectId);

            var result = _noSearchDbContext.ResourceUserEntities.Add(
                new ResourceUserEntity()
                {
                    Resource = resource,
                    User = user
                });
            return (result.State == Microsoft.EntityFrameworkCore.EntityState.Added);            
        }

        public IEnumerable<ResourceEntity> SearchAll(string searchText)
        {
            // Search Url first
            var urlResults = _noSearchDbContext.ResourceEntities
                .Where(a => a.Url.Contains(searchText)
                && a.IsApproved);

            if (urlResults.Any())
            {
                return urlResults;
            }

            // Search Description if no Url results found
            var descriptionResults = _noSearchDbContext.ResourceEntities
                .Where(a => a.Description.Contains(searchText)
                && a.IsApproved);

            if (descriptionResults.Any())
            {
                return descriptionResults;
            }

            return new List<ResourceEntity>();
        }

        public IEnumerable<Resource> ByUser(string subjectId)
        {
            var results = _noSearchDbContext.ResourceUserEntities
                .Where(a => a.User.Id == subjectId)
                .Include(a => a.Resource).ToList()
                .Select(a => a.Resource);            

            return results;
        }
    }
}
