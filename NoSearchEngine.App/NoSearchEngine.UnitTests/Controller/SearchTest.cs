﻿using Microsoft.Extensions.Logging;
using NoSearchEngine.App.Controllers;
using NoSearchEngine.Models;
using NoSearchEngine.Service.Interfaces;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            var logger = Substitute.For<ILogger<SearchController>>();
            var searchService = Substitute.For<ISearchService>();
            searchService.SearchAll(searchText)
                .Returns(new List<Resource>()
                {
                    new Resource() { Url = "www.test.com", Description = expectedResult }
                });
            
            var searchController = new SearchController(logger, searchService);

            // Act
            var results = searchController.Search(searchText);

            // Assert
            Assert.Single(results);
            Assert.Equal(expectedResult, results.First().Description);

        }
    }
}