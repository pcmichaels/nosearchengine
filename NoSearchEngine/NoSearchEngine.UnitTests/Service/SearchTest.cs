using NoSearchEngine.DataAccess;
using NoSearchEngine.Service;
using NSubstitute;
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
            var resultSet = Data.SearchResults.GetSingleSearchResult(expectedResult);
            resourceDataAccess.SearchAll(searchText)
                .Returns(resultSet);
            var searchService = new SearchService(resourceDataAccess);

            // Act
            var results = searchService.SearchAll(searchText);

            // Assert
            Assert.Single(results);
            Assert.Equal(expectedResult, results.First().Description);
        }
    }
}
