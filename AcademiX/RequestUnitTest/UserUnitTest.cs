using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Xunit;
using AcademiX.Models;

namespace UnitTests
{
    [TestClass]
    public class UserUnitTest
    {
        [TestMethod]
        public void UserPropertiesShouldBeSetCorrectly()
        {
            // Arrange
            var user = new Models.User
            {
                Id = 1,
                Username = "johndoe",
                Password = "password123",
                FirstName = "John",
                LastName = "Doe"
            };

            // Act and Assert
            Assert.AreEqual(1, user.Id);
            Assert.AreEqual("johndoe", user.Username);
            Assert.AreEqual("password123", user.Password);
            Assert.AreEqual("John", user.FirstName);
            Assert.AreEqual("Doe", user.LastName);
        }
    }
}

