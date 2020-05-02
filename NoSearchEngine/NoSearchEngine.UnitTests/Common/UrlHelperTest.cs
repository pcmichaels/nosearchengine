using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NoSearchEngine.UnitTests.Common
{
    public class UrlHelperTest
    {
        [Theory]
        [InlineData("www.test.com", "test.com")]
        [InlineData("http://www.test.com", "test.com")]
        [InlineData("https://www.test.com", "test.com")]
        [InlineData("http://test.com", "test.com")]
        [InlineData("https://test.com", "test.com")]
        [InlineData("test.com", "test.com")]        
        [InlineData("http://test.com/path?query=123&1=1", "test.com/path?query=123&1=1")]
        [InlineData("http://www.test.com/path?query=123&1=1", "test.com/path?query=123&1=1")]
        [InlineData("https://www.test.com/path?query=123&1=1", "test.com/path?query=123&1=1")]
        [InlineData("test.com/path?value=www.1", "test.com/path?value=www.1")]
        public void GetBase_ReturnsBase(string url, string expectedUrl)
        {
            // Arrange

            // Act
            string baseUrl = NoSearchEngine.Common.Helpers.UrlHelper.GetUrlBase(url);

            // Assert
            Assert.Equal(expectedUrl, baseUrl);
        }
    }
}
