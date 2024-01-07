using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Xunit;
using AcademiX.Models;


namespace UnitTests
{
    [TestClass]
    public class DegreeSupervisorUnitTests
    {
        [TestMethod]
        public void DegreeSupervisorPropertiesShouldBeSetCorrectly()
        {
            // Arrange
            var supervisor = new Models.DegreeSupervisor
            {
                Id = 1,
                Email = "john.doe@example.com",
                Cabinet = 123,
                WorkingTime = "9:00 AM - 5:00 PM",
                IsReviewer = true
            };

            // Act and Assert
            Assert.AreEqual(1, supervisor.Id);
            Assert.AreEqual("john.doe@example.com", supervisor.Email);
            Assert.AreEqual(123, supervisor.Cabinet);
            Assert.AreEqual("9:00 AM - 5:00 PM", supervisor.WorkingTime);
            Assert.IsTrue(supervisor.IsReviewer);
        }
    }
}
