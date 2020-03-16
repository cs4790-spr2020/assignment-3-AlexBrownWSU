using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;
using System.Threading;

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
            string actual = harness.UserID; 
            
            // Assert
            Assert.AreEqual(actual.ToString, expected.ToString);
        }
        [TestMethod]
        public void TestSetGetUserID_Fail00()
        {
            // Arrange
            User harness = new User(); 
            // Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.UserID = "Foobar");
            // Assert
            Assert.AreEqual("DUH, not an email", ex.Message.toString);
        }
        [TestMethod]
        public void TestSetGetUserID_Fail01()
        {
            // Arrange
            User harness = new User(); 
            // Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.UserID = "example.com");
            // Assert
            Assert.AreEqual("DUH, not an email", ex.Message.ToString());
        }
        [TestMethod]
        public void TestSetGetUserID_Fail02()
        {
            // Arrange
            User harness = new User(); 
            // Act
            var ex = Assert.ThrowsException<FormatException>(() => harness.UserID = "foobar.example");
            // Assert
            Assert.AreEqual("DUH, not an email", ex.Message.ToString());
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
            Assert.AreEqual(actual, expected.ToString());
            Assert.AreEqual(true, harness.getSysId() is string);
        }

        [TestMethod]
        public void sysIdFail(){

            // Arrange
            User harness = new User();
            User testHarness = new User();

            // Act
            bool equals = harness.Equals(testHarness.getSysId());

            // Arrange
            Assert.AreEqual(false, equals);
        }

        [TestMethod]
        public void sysIdTest(){

            // Arrange 
            User harness = new User();

            // Act 
            bool equals = harness.Equals(harness.getSysId());

            // Assert
            Assert.AreEqual(true, equals);
        }

        [TestMethod]
        public void createDTTM(){

            // Arrange
            User Expected = new User();

            // Act 
            User Actual = new User();

            // Assert
            Assert.AreEqual(Expected.CreatedDTTM.ToString(), Actual.CreatedDTTM.ToString());
        }

        [TestMethod]
        public void createDTTMFail(){

            // Arrange
            User Expected = new User();
            Thread.Sleep(1000);
            User Actual = new User();

            // Assert
            Assert.AreNotEqual(Expected.CreatedDTTM.ToString(), Actual.CreatedDTTM.ToString());
        }
        [TestMethod]
        public void modifiedDTTM(){
            User Expected = new User();
            User Actual = new User();
            Assert.AreEqual(Expected.ModifiedDTTM.ToString(), Actual.ModifiedDTTM.ToString());
        }

        [TestMethod]
        public void modifiedDTTMFail(){

            // Arrange
            User Expected = new User();
            Thread.Sleep(1000);
            User Actual = new User();

            // Assert
            Assert.AreNotEqual(Expected.ModifiedDTTM.ToString(), Actual.ModifiedDTTM.ToString());
        }   


    }
}
