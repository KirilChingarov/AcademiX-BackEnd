using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class RegisterViewModelUnitTest
    {
        [TestMethod]
        public void RegisterViewModelPropertiesShouldBeRequired()
        {
            // Arrange
            var registerViewModel = new Models.RegisterViewModel
            {
                Username = "john.doe",
                Password = "password123",
                ConfirmPassword = "password123"
            };

            // Act and Assert
            Assert.AreEqual("john.doe", registerViewModel.Username);
            Assert.AreEqual("password123", registerViewModel.Password);
            Assert.AreEqual("password123", registerViewModel.ConfirmPassword);

            // Validate Data Annotations
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(registerViewModel, null, null);
            var results = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();

            // Act
            bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(registerViewModel, context, results, true);

            // Assert
            Assert.IsTrue(isValid, "Data annotations validation failed. " + string.Join(", ", results.Select(r => r.ErrorMessage)));
        }
    }
}
