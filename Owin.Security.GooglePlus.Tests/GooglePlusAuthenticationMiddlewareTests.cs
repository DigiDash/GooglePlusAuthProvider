using System;
using FluentAssertions;
using Microsoft.Owin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Owin.Security.GooglePlus
{
    [TestClass]
    public class GooglePlusAuthenticationMiddlewareTests
    {
        private const string ClientId = "ClientId";
        private const string ClientSecret = "ClientSecret";

        private OwinMiddleware nextMiddleware;
        private IAppBuilder appBuilder;

        [TestInitialize]
        public void SetUp()
        {
            appBuilder = Substitute.For<IAppBuilder>();
        }

        [TestMethod]
        public void ConstructorShouldThrowWhenClientIdIsNull()
        {
            // Arrange
            var options = new GooglePlusAuthenticationOptions
            {
                ClientId = null,
                ClientSecret = ClientSecret
            };

            // Act
            Action action = () => new GooglePlusAuthenticationMiddleware(null, appBuilder, options);

            // Assert
            action.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void ConstructorShouldThrowWhenClientIdIsEmpty()
        {
            // Arrange
            var options = new GooglePlusAuthenticationOptions
            {
                ClientId = "",
                ClientSecret = ClientSecret
            };

            // Act
            Action action = () => new GooglePlusAuthenticationMiddleware(null, appBuilder, options);

            // Assert
            action.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void ConstructorShouldThrowWhenClientSecretIsNull()
        {
            // Arrange
            var options = new GooglePlusAuthenticationOptions
            {
                ClientId = ClientId,
                ClientSecret = null
            };

            // Act
            Action action = () => new GooglePlusAuthenticationMiddleware(null, appBuilder, options);

            // Assert
            action.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void ConstructorShouldThrowWhenClientSecretIsEmpty()
        {
            // Arrange
            var options = new GooglePlusAuthenticationOptions
            {
                ClientId = ClientId,
                ClientSecret = ""
            };

            // Act
            Action action = () => new GooglePlusAuthenticationMiddleware(null, appBuilder, options);

            // Assert
            action.ShouldThrow<ArgumentException>();
        }
    }
}
