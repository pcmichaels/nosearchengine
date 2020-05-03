using Microsoft.Extensions.Logging;
using NoSearchEngine.App.Controllers;
using NoSearchEngine.Models;
using NoSearchEngine.Service.Interfaces;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NoSearchEngine.UnitTests.Controller
{
    public class SearchTest
    {
        [Fact]
        public void Search_ReturnsValidResult_Description()
        {
            // Arrange
            string searchText = "should exist";
            string expectedResult = "this test should exist";

            var logger = Substitute.For<ILogger<ResourceController>>();            
            var approvalService = Substitute.For<IApprovalService>();
            var userService = Substitute.For<IUserService>();
            var searchService = Substitute.For<ISearchService>();
            searchService.SearchAll(searchText)
                .Returns(new List<Resource>()
                {
                    new Resource() { Url = "www.test.com", Description = expectedResult }
                });
            var addResourceService = Substitute.For<IAddResourceService>();

            var searchController = new ResourceController(
                logger, searchService, addResourceService, 
                approvalService, userService);

            // Act
            var results = searchController.Search(searchText);

            // Assert
            Assert.Single(results);
            Assert.Equal(expectedResult, results.First().Description);

        }
    }
}
