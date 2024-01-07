using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Xunit;
using AcademiX.Models;


namespace UnitTests
{
    [TestClass]
    public class RequestUnitTests
    {
        [TestMethod]
        public void Request_SetAndGetProperties_ValuesAreEqual()
        {
            // Arrange
            var request = new Request();
            int expectedId = 1;
            int expectedStudentId = 123;
            int expectedSupervisorId = 456;
            int expectedDegreeId = 789;
            RequestStatus expectedStatus = RequestStatus.Accepted;

            // Act
            request.Id = expectedId;
            request.StudentId = expectedStudentId;
            request.DegreeSupervisorId = expectedSupervisorId;
            request.DegreeId = expectedDegreeId;
            request.Status = expectedStatus;

            // Assert
            Assert.Equal(expectedId, request.Id);
            Assert.Equal(expectedStudentId, request.StudentId);
            Assert.Equal(expectedSupervisorId, request.DegreeSupervisorId);
            Assert.Equal(expectedDegreeId, request.DegreeId);
            Assert.Equal(expectedStatus, request.Status);
        }
    }

}
