using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Xunit;
using AcademiX.Models;

namespace UnitTests
{
    [TestClass]
    public class SpecialtyUnitTests
    {
        [TestMethod]
        public void SpecialtyPropertiesShouldBeSetCorrectly()
        {
            // Arrange
            var specialty = new Models.Specialty
            {
                Id = 1,
                Name = "Computer Science",
                Description = "The study of computers and computational systems."
            };

            // Act and Assert
            Assert.AreEqual(1, specialty.Id);
            Assert.AreEqual("Computer Science", specialty.Name);
            Assert.AreEqual("The study of computers and computational systems.", specialty.Description);

            // Validate Data Annotations
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(specialty, null, null);
            var results = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();

            // Act
            bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(specialty, context, results, true);

            // Assert
            Assert.IsTrue(isValid, "Data annotations validation failed. " + string.Join(", ", results.Select(r => r.ErrorMessage)));
        }

        [TestMethod]
        public void SpecialtyConstructorsShouldSetDefaultValues()
        {
            // Arrange
            var specialtyDefault = new Models.Specialty();
            var specialtyWithId = new Models.Specialty(2);
            var specialtyWithValues = new Models.Specialty(3, "Mathematics", "The study of numbers and structures.");

            // Act and Assert
            Assert.AreEqual(-1, specialtyDefault.Id);
            Assert.AreEqual(string.Empty, specialtyDefault.Name);
            Assert.AreEqual(string.Empty, specialtyDefault.Description);

            Assert.AreEqual(2, specialtyWithId.Id);
            Assert.AreEqual(string.Empty, specialtyWithId.Name);
            Assert.AreEqual(string.Empty, specialtyWithId.Description);

            Assert.AreEqual(3, specialtyWithValues.Id);
            Assert.AreEqual("Mathematics", specialtyWithValues.Name);
            Assert.AreEqual("The study of numbers and structures.", specialtyWithValues.Description);
        }
    }
}
