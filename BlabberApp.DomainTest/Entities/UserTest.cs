using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest.Entities
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestSetGetUserID_Success()
        {
            // Arrange
            User harness = new User(); 
            string expected = "foobar@example.com";
            harness.UserID = "foobar@example.com";
            // Act
            string actual = harness.UserID; // Assert
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void TestSetGetUserID_Fail00()
        {
            // Arrange
            User harness = new User(); 
            // Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.UserID = "Foobar");
            // Assert
            Assert.AreEqual("DUH, not an email", ex.Message);
        }
        [TestMethod]
        public void TestSetGetUserID_Fail01()
        {
            // Arrange
            User harness = new User(); 
            // Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.UserID = "example.com");
            // Assert
            Assert.AreEqual("DUH, not an email", ex.Message);
        }
        [TestMethod]
        public void TestSetGetUserID_Fail02()
        {
            // Arrange
            User harness = new User(); 
            // Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.UserID = "foobar.example");
            // Assert
            Assert.AreEqual("DUH, not an email", ex.Message);
        }
        [TestMethod]
        public void TestGetSysId()
        {
            // Arrange
            User harness = new User();
            string expected = harness.getSysId();
            // Act
            string actual = harness.getSysId();
            // Assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(true, harness.getSysId() is string);
        }
    }
}
