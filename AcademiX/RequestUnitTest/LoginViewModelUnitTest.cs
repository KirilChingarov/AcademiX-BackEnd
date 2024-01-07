using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Xunit;
using AcademiX.Models;

namespace UnitTests
{
    [TestClass]
    public class LoginViewModelUnitTest
    {
        [TestMethod]
        public void LoginViewModelPropertiesShouldBeRequired()
        {
            // Arrange
            var loginViewModel = new Models.LoginViewModel
            {
                Username = "john.doe",
                Password = "password123"
            };

            // Act and Assert
            Assert.AreEqual("john.doe", loginViewModel.Username);
            Assert.AreEqual("password123", loginViewModel.Password);

            // Validate Data Annotations
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(loginViewModel, null, null);
            var results = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();

            // Act
            bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(loginViewModel, context, results, true);

            // Assert
            Assert.IsTrue(isValid, "Data annotations validation failed. " + string.Join(", ", results.Select(r => r.ErrorMessage)));
        }
    }
}
