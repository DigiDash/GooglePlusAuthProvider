using System;
using FluentAssertions;
using Microsoft.Owin.Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Owin.Security.GooglePlus
{
    [TestClass]
    public class GooglePlusAuthenicationExtensionsTests
    {
        private IAppBuilder appBuilder;
        private GooglePlusAuthenticationOptions options;

        [TestMethod]
        public void ShouldThrowWhenAppBuilderIsNull()
        {
            // Arrange
            options = new GooglePlusAuthenticationOptions();

            // Act
            Action action = () => appBuilder.UseGooglePlusAuthentication(options);

            // Assert
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("app");
        }

        [TestMethod]
        public void ShouldThrowWhenOptionsIsNull()
        {
            // Arrange
            appBuilder = new AppBuilder();

            // Act
            Action action = () => appBuilder.UseGooglePlusAuthentication(null);

            // Assert
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("options");
        }
    }
}