using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Xunit;
using AcademiX.Models;


namespace UnitTests
{
    [TestClass]
    public class DegreeProjectUnitTests
    {
        [TestMethod]
        public void CreateDegreeProject_AssignProperties_CorrectlyAssigned()
        {
            // Arrange
            var id = 1;
            var studentId = 101;
            var supervisorId = 102;
            var reviewerId = 103;
            var title = "Degree Project Title";
            var description = "This is a description of the degree project.";
            var status = DegreeStatus.InProgress;

            // Act
            var degreeProject = new DegreeProject();

            // Assert
            Assert.Equal(id, degreeProject.Id);
            Assert.Equal(studentId, degreeProject.StudentId);
            Assert.Equal(supervisorId, degreeProject.DegreeSupervisorId);
            Assert.Equal(reviewerId, degreeProject.ReviewerId);
            Assert.Equal(title, degreeProject.Title);
            Assert.Equal(description, degreeProject.Description);
            Assert.Equal(status, degreeProject.Status);
        }
    }

}
