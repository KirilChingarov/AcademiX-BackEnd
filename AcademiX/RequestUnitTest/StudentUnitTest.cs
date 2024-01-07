using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Xunit;
using AcademiX.Models;

namespace UnitTests
{
    [TestClass]
    public class StudentUnitTests
    {
        [TestMethod]
        public void StudentPropertiesShouldBeSetCorrectly()
        {
            // Arrange
            var student = new Models.Student
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                User = new Models.User
                {
                    Username = "johndoe",
                    Password = "password123"
                }
            };

            // Act and Assert
            Assert.AreEqual(1, student.Id);
            Assert.AreEqual("John", student.FirstName);
            Assert.AreEqual("Doe", student.LastName);

            // Email property should have the EmailAddress attribute
            var emailAttribute = student.GetType().GetProperty("Email")
                                   .GetCustomAttributes(typeof(EmailAddressAttribute), false)
                                   .FirstOrDefault() as EmailAddressAttribute;
            Assert.IsNotNull(emailAttribute);

            Assert.AreEqual("john.doe@example.com", student.Email);

            Assert.IsNotNull(student.User);
            Assert.AreEqual("johndoe", student.User.Username);
            Assert.AreEqual("password123", student.User.Password);
        }
    }
 
}
