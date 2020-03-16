using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;
using System;
using System.Threading;

namespace BlabberApp.DomainTest.Entities{
    [TestClass]
    public class BlabTest{

        //Blab Test - setGetMessage
        [TestMethod]
        public void setGetMessage() {

            // Arrange
            Blab harness = new Blab(); 
            string expected = "Blab Test"; 
            harness.Message = "Blabe Test";
             
            // Act
            string actual = harness.Message;

            // Assert
            Assert.AreEqual(actual, expected);
        }

        //Test Blab - setMessageFail
        [TestMethod]
        public void setMessageFail() {

            // Arrange
            Blab harness = new Blab(); 
            string expected = "Blab Test #1"; 
            harness.Message = "Blab Test #2";

            // Act
            string actual = harness.Message;

            // Assert
            Assert.AreNotEqual(actual, expected);
        }

        //Test Blab - setUserId
        [TestMethod]
        public void setUserId(){

            // Arrange 
            Blab harness = new Blab(); 
            string expected = "foo@example.com";
            harness.UserID = "foo@example.com";

            // Act
            string actual = harness.UserID;

            // Assert
            Assert.AreEqual(actual.ToString(), expected.ToString());
        }

        //Test Blab - setUserIdFail
        [TestMethod]
        public void setUserIdFail(){

            // Arrange
            Blab harness = new Blab(); 
            string expected = "foo1@example.com";
            harness.UserID = "foo@example.com";

            // Act
            string actual = harness.UserID;

            // Arrange
            Assert.AreNotEqual(actual.ToString(), expected.ToString());
        }

        //Test Blab
        [TestMethod]
        public void getSysId(){

            // Arrange
            Blab harness = new Blab();
            string expected = harness.getSysId();
            string actual = harness.getSysId();

            // Act
            Assert.AreEqual(actual.ToString(), expected.ToString());

            // Assert
            Assert.AreEqual(true, harness.getSysId() is string);
        }

        //Test Blab - sysIdFail
        [TestMethod]
        public void sysIdfail(){

            // Arrange
            Blab harness = new Blab();
            Blab testHarness = new Blab();

            // Act
            bool equals = harness.Equals(testHarness.getSysId());

            // Assert
            Assert.AreEqual(false, equals);
        }

        //Test Blab - sysIdTest
        [TestMethod]
        public void sysIdTest(){

            // Arrange
            Blab harness = new Blab();

            // Act
            bool equals = harness.Equals(harness.getSysId());

            // Assert
            Assert.AreEqual(true, equals);
        }

        // Test Blab - createDTTM
        [TestMethod]
        public void createDTTM(){

            // Arrange 
            Blab Expected = new Blab();
            Blab Actual = new Blab();

            // Assert
            Assert.AreEqual(Expected.CreatedDTTM.ToString(), Actual.CreatedDTTM.ToString());
        }

        // Test Blab - createDTTMFail
        [TestMethod]
        public void creatDTTMFail(){

            // Arrange
            Blab Expected = new Blab();
            Thread.Sleep(1000);
            Blab Actual = new Blab();

            // Assert
            Assert.AreNotEqual(Expected.CreatedDTTM.ToString(), Actual.CreatedDTTM.ToString());
        }

        // Test Blab - modifiedDTTM
        [TestMethod]
        public void modifiedDTTM(){

            // Arrange 
            Blab Expected = new Blab();
            Blab Actual = new Blab();

            // Assert
            Assert.AreEqual(Expected.ModifiedDTTM.ToString(), Actual.ModifiedDTTM.ToString());
        }

        //Test Blab - moddifiedDTTMFail
        [TestMethod]
        public void modifiedDTTMFail(){

            // Arrange
            Blab Expected = new Blab();
            Thread.Sleep(1000);
            Blab Actual = new Blab();

            // Assert
            Assert.AreNotEqual(Expected.ModifiedDTTM.ToString(), Actual.ModifiedDTTM.ToString());
        }
    }
}