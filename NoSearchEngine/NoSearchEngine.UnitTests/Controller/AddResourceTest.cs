using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NoSearchEngine.App.Controllers;
using NoSearchEngine.Models;
using NoSearchEngine.Service.Interfaces;
using NSubstitute;
using System.Security.Principal;
using System.Threading.Tasks;
using Xunit;

namespace NoSearchEngine.UnitTests.Controller
{
    public class AddResourceTest
    {
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task AddResource_ReturnsCorrectResult(bool isValid)
        {
            // Arrange
            var resourceToAdd = new Resource()
            {
                Url = "www.test.com",
                IsApproved = false,
                Description = "test description"
            };

            var logger = Substitute.For<ILogger<ResourceController>>();
            var searchService = Substitute.For<ISearchService>();
            var approvalService = Substitute.For<IApprovalService>();

            var userService = Substitute.For<IUserService>();
            userService.GetSubjectId(Arg.Any<IPrincipal>()).Returns("1");

            var addResourceService = Substitute.For<IResourceService>();
            addResourceService.AddResource(resourceToAdd, "1").Returns(
                new DataResult<Resource>()
                {
                    IsSuccess = isValid,
                    Data = resourceToAdd,
                    Errors = new [] {"error1"}
                });

            var controller = new ResourceController(
                logger, searchService, addResourceService,
                approvalService, userService);

            // Act
            var result = await controller.AddResource(resourceToAdd);

            // Assert
            Assert.NotNull(result);
            if (isValid)
            {
                Assert.True(result is OkObjectResult);                
            }
            else
            {
                Assert.True(result is BadRequestObjectResult);
            }            
        }
    }
}
