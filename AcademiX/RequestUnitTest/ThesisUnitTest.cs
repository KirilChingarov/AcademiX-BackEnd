using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Xunit;
using AcademiX.Models;

namespace UnitTests
{
    [TestClass]
    public class ThesisUnitTest
    {
        [TestMethod]
        public void ThesisPropertiesShouldBeSetCorrectly()
        {
            // Arrange
            var thesis = new Models.Thesis
            {
                Id = 1,
                Title = "Advanced Algorithms",
                Description = "A study of advanced algorithms and their applications."
            };

            // Act and Assert
            Assert.AreEqual(1, thesis.Id);
            Assert.AreEqual("Advanced Algorithms", thesis.Title);
            Assert.AreEqual("A study of advanced algorithms and their applications.", thesis.Description);

            // Validate Data Annotations
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(thesis, null, null);
            var results = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();

            // Act
            bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(thesis, context, results, true);

            // Assert
            Assert.IsTrue(isValid, "Data annotations validation failed. " + string.Join(", ", results.Select(r => r.ErrorMessage)));
        }

        [TestMethod]
        public void ThesisConstructorsShouldSetDefaultValues()
        {
            // Arrange
            var thesisWithId = new Models.Thesis(2);
            var thesisWithValues = new Models.Thesis(3, "Machine Learning", "An exploration of machine learning techniques.");

            // Act and Assert
            Assert.AreEqual(2, thesisWithId.Id);
            Assert.AreEqual(string.Empty, thesisWithId.Title);
            Assert.AreEqual(string.Empty, thesisWithId.Description);

            Assert.AreEqual(3, thesisWithValues.Id);
            Assert.AreEqual("Machine Learning", thesisWithValues.Title);
            Assert.AreEqual("An exploration of machine learning techniques.", thesisWithValues.Description);
        }
    }
}

