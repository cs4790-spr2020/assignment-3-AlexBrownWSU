using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore;
using System;
using System.Collections.Generic;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class InMemory_Blab_UnitTests {
        private InMemory<Blab> _harness;
        public InMemory_Blab_UnitTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes")
                .Options;
            _harness = new InMemory<Blab>(new ApplicationContext(options));
        }

        //Test Blab - getBySysId
        [TestMethod]
        public void addBlabBySysId()
        {
            // Arrange
            Blab blab = new Blab();
            blab.Message = "Test Blab";
            blab.UserID = "foo@examlpe.com";

            string sysId = blab.getSysId();

            // Act
            _harness.Add(blab);
            Blab blabFromInMemory = (Blab)_harness.GetBySysId(sysId);

            // Assert
            Assert.AreEqual(blabFromInMemory, blab);
        }

        //Test Blab - getByUserId
        [TestMethod]
        public void addBlabByUserId() {

            // Arrange
            Blab Expected = new Blab();
            string Username = "foo@example.com";
            Expected.Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer gravida posuere pretium. Cras maximus nibh sed accumsan elementum. Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            Expected.UserID = Username;
            _harness.Add(Expected);
            
            // Act
            Blab Actual = (Blab)_harness.GetByUserId(Username);
            
            // Assert
            Assert.AreEqual(Expected, Actual);

        }

        //Test Blab - deleteBySysId
        [TestMethod]
        public void deleteBySysId() {

            // Arrange 
            Blab blab = new Blab();
            blab.Message = "Test Blab";
            blab.UserID = "foo3@example.com";

            // Act 
            _harness.Add(blab);
            int length = _harness.GetEntityLength();
            _harness.Remove(blab);

            int newLength = _harness.GetEntityLength();
            
            bool deleted = false;
            if(newLength == (length - 1)){
                deleted = true;
            }

            // Assert
            Assert.AreEqual(true, deleted);

        } 

        //Test Blab - updateBlabBySysId
        [TestMethod]

        public void Update_Blab() {

            // Arrange
            //Blab blab = new Blab();
            //blab.Message = "Test Blab";
            //blab.UserID = "foo4@example.com";
            //string sysId = blab.getSysId();

            string username = "foo4@example.com";
            Blab expected = (Blab)_harness.GetByUserId(username);
            expected.Message = "Test Blab";

            // Act 
            //_harness.Add(blab);
            //blab.Message = "Test Blab #2";
            _harness.Update(expected);
            
            // Assert
            Blab blabFromInMemory = (Blab)_harness.GetByUserId(username);
            Assert.AreEqual(expected, blabFromInMemory);
        }

        //Test Blab - getAllBlabs
        [TestMethod]

        public void getAllBlabs() {

            // Arrange 
            Blab blab = new Blab();
            blab.Message = "Test Blab";
            blab.UserID = "foo@example.com";

            // Act
            IEnumerable<BaseEntity> blabs = _harness.GetAll();
            bool hasBlabs = false;

            if (blabs.Count() > 0) {
                hasBlabs = true; 
            }
            
            //Assert
            Assert.AreEqual(hasBlabs, true);
        }
    }
}
