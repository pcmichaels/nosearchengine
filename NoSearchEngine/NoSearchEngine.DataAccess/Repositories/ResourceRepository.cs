﻿using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NoSearchEngine.DataAccess.Entities;
using NoSearchEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSearchEngine.DataAccess
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly NoSearchDbContext _noSearchDbContext;

        public ResourceRepository(NoSearchDbContext noSearchDbContext)
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

        public Resource ByUrl(string url)
        {
            string urlBase = Common.Helpers.UrlHelper.GetUrlBase(url);
            
            var matches = _noSearchDbContext.ResourceEntities.Where(a =>
                a.Url.Contains(urlBase));

            var match = matches.AsEnumerable().FirstOrDefault(a =>
                Common.Helpers.UrlHelper.GetUrlBase(a.Url) == urlBase);

            return match;
        }

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

        public IEnumerable<Resource> ByApproval(bool isApprovedFilter)
        {
            var results = _noSearchDbContext.ResourceEntities
                .Where(a => a.IsApproved == isApprovedFilter);

            return results;
        }

        public Resource ById(string id)
        {
            var resource = _noSearchDbContext.ResourceEntities.Find(id);
            return resource;
        }

        public async Task<DataResult<Resource>> ApproveById(string id)
        {
            var resource = _noSearchDbContext.ResourceEntities.Find(id);
            resource.IsApproved = true;
            if ((await _noSearchDbContext.SaveChangesAsync()) != 0)
            {
                return DataResult<Resource>.Success(resource);
            }
            return DataResult<Resource>.Error("Unable to save changes");
        }

        public async Task<DataResult<Resource>> DeleteById(string id)
        {
            var resource = _noSearchDbContext.ResourceEntities.Find(id);
            if (resource.IsApproved)
            {
                return DataResult<Resource>.Error(resource, "Can not remove an approved resource");
            }

            var resourceUsers = _noSearchDbContext.ResourceUserEntities
                .Where(a => a.Resource.Id == id);
            if (resourceUsers.Any())
            {
                _noSearchDbContext.ResourceUserEntities
                    .RemoveRange(resourceUsers);
            }

            var result = _noSearchDbContext.Remove(resource);
            if (result.State != EntityState.Deleted)
            {
                return DataResult<Resource>.Error(resource, "Unable to delete resource");
            }

            int changeCount = await _noSearchDbContext.SaveChangesAsync();
            if (changeCount == 0)
            {
                return DataResult<Resource>.Error(resource, "Unable to save changes");
            }

            return DataResult<Resource>.Success();
        }
    }
}