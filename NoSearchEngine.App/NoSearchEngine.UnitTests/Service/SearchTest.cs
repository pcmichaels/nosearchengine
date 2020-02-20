using NoSearchEngine.DataAccess;
using NoSearchEngine.DataAccess.Entities;
using NoSearchEngine.Service;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NoSearchEngine.UnitTests.Service
{
    public class SearchTest
    {
        [Fact]
        public void Search_ReturnsValidResult_Description()
        {
            // Arrange
            string searchText = "should exist";
            string expectedResult = "this test should exist";

            var resourceDataAccess = Substitute.For<IResourceDataAccess>();
            resourceDataAccess.SearchAll(searchText)
                .Returns(new List<ResourceEntity>()
                {
                    new ResourceEntity() { Url = "www.test.com", Description = expectedResult }
                });
            var searchService = new SearchService(resourceDataAccess);

            // Act
            var results = searchService.Search(searchText);

            // Assert
            Assert.Single(results);
            Assert.Equal(expectedResult, results.First().Description);
        }
    }
}
