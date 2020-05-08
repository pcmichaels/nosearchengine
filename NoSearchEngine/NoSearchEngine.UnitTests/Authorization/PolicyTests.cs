using Microsoft.AspNetCore.Authorization;
using NoSearchEngine.App.Authorization;
using NoSearchEngine.Service.Interfaces;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NoSearchEngine.UnitTests.Authorization
{
    public class PolicyTests
    {
        [Theory]
        [InlineData(100, 100, true)]
        [InlineData(100, 99, false)]
        [InlineData(100, -1, false)]
        [InlineData(-1, -1, true)]
        public async Task UserRating_AuthorisedIfSufficient(int requiredRating, int userRating, bool isExpectedToSucceed)
        {
            // Arrange
            var requirements = new[] { new ApproverAuthRequirement(requiredRating) };            
            var user = new ClaimsPrincipal(
                        new ClaimsIdentity(
                            new Claim[] { },
                            "Basic")
                        );

            var userService = Substitute.For<IUserService>();
            userService.GetSubjectRating(Arg.Any<IPrincipal>()).Returns(userRating);

            var context = new AuthorizationHandlerContext(requirements, user, null);
            var sut = new ApproverAuthHandler(userService);

            // Act
            await sut.HandleAsync(context);

            // Assert
            Assert.Equal(isExpectedToSucceed, context.HasSucceeded);
        }
    }
}
