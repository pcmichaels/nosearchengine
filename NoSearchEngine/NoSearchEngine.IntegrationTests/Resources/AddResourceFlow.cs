using Microsoft.Extensions.Logging;
using NoSearchEngine.App.Controllers;
using NoSearchEngine.Service.Interfaces;
using NSubstitute;
using Xunit;
using NoSearchEngine.Models;
using NoSearchEngine.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Options;
using IdentityServer4.EntityFramework.Options;
using System.Security.Principal;
using NoSearchEngine.Service;
using WebSiteMeta.Scraper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace NoSearchEngine.IntegrationTests.Resources
{
    public class AddResourceFlow
    {
        NoSearchDbContext _noSearchDbContext;
        IResourceDataAccess _resourceDataAccess;
        IApprovalService _approvalService;

        public AddResourceFlow()
        {
            SetupDbContext();
            SetupClasses();
        }

        private void SetupDbContext()
        {
            var options = new DbContextOptionsBuilder<NoSearchDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;
            var operationalStoreOptions = Options.Create<OperationalStoreOptions>(new OperationalStoreOptions());
            _noSearchDbContext = new NoSearchDbContext(options, operationalStoreOptions);
            _noSearchDbContext.Database.EnsureCreated();
        }

        private void SetupClasses()
        {
            _resourceDataAccess = new ResourceDataAccess(_noSearchDbContext);
            _approvalService = new ApprovalService(_resourceDataAccess);
        }

        [Fact]
        public async Task AddResource_Approve()
        {
            // Arrange
            string urlTest = "www.test.com";
            var resourceToAdd = new Resource()
            {
                Url = urlTest,
                IsApproved = false,
                Description = "test description"
            };

            var logger = Substitute.For<ILogger<ResourceController>>();
            var searchService = Substitute.For<ISearchService>();            

            var userService = Substitute.For<IUserService>();
            userService.GetSubjectId(Arg.Any<IPrincipal>()).Returns("1");

            var findMetaData = Substitute.For<IFindMetaData>();
            findMetaData.ValidateUrl(urlTest).Returns(true);
            findMetaData.CleanUrl(urlTest).Returns(urlTest);

            var addResourceService = new ResourceService(_resourceDataAccess, findMetaData);
            var controller = new ResourceController(
                logger, searchService, addResourceService,
                _approvalService, userService);

            // Flow
            var result = await controller.AddResource(resourceToAdd) as OkObjectResult;
            Assert.NotNull(result);

            var list = controller.ApprovalList();
            var approvalId = list.Single(a => a.Url == urlTest).Id;

            var approveResult = await controller.ApproveResource(approvalId) as OkObjectResult;
            Assert.NotNull(approveResult);
            Assert.True(((Resource)approveResult.Value).IsApproved);
        }
    }
}
