using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Runtime.CompilerServices;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore;
using System;
using System.Collections.Generic;
using BlabberApp.Domain.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlabberApp.DataStoreTest {
    [TestClass]
    public class InMemory_User_UnitTests {

        private InMemory<User> _harness;

        public InMemory_User_UnitTests() {

            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes")
                .Options;
            _harness = new InMemory<User>(new ApplicationContext(options));
        }

        //Test User - addUserByUserId
        [TestMethod]
        public void addUserByUserId() {

            // Arrange 
            User expected = new User();
            expected.ChangeEmail("foo9@example.com");
            var email = expected.Email;
            _harness.Add(expected);

            // Act 
            User actual = (User)_harness.GetByUserId(email);
            
            // Assert 
            Assert.AreEqual(expected, actual);
        }

        //Test User - addUserBySysId
        [TestMethod]
        public void addUserBySysId() {

            // Arrange
            User user = new User();
            user.ChangeEmail("foo8@example.com");
            string sysID = user.getSysId();
            _harness.Add(user);

            // Act 
            User userFromInMemory = (User)_harness.GetBySysId(sysID);

            //Assert
            Assert.AreEqual(userFromInMemory, user);
        }

        //Test User - removeBySysId
        [TestMethod]
        public void removeBySysId(){

            // Arrange
            User user = new User();
            user.ChangeEmail("foo7@example.com");
            _harness.Add(user);

            // Act
            int length = _harness.GetEntityLength();
            _harness.Remove(user);
            int newLength = _harness.GetEntityLength();
            bool deleted = false;

            if(newLength == (length - 1)){
                deleted = true;
            }

            // Assert
            Assert.AreEqual(true, deleted);
        }

        //Test User - updateUser
        [TestMethod]
        public void updateUser(){
            
            // Arrange 
            User user = new User();
            user.ChangeEmail("foo6@example.com");
            string sysID = user.getSysId();
            _harness.Add(user);
            _harness.Update(user);

            // Act
            User userFromInMemory = (User)_harness.GetBySysId(sysID);
            

            // Assert
            //Assert.AreEqual(user, userFromInMemory);
            //Assert.IsTrue(user.getSysId() == userFromInMemory.getSysId(), "Error");
            //Assert.AreEqual(userFromInMemory, user);
            //Assert.That(user, Is.EqualTo(userFromInMemory));
            //userFromInMemory.ShouldEqual(user);

            /*string jsonString1;
            jsonString1 = JsonSerializer.Serialize(user);

            string jsonString2;
            jsonString2 = JsonSerializer.Serialize(userFromInMemory);

            Assert.AreEqual(jsonString1, jsonString2);*/

            //Assert.AreEqual(user.Email.ToString(), userFromInMemory.Email.ToString());
            Assert.AreEqual(user, userFromInMemory);
        }

        //Test User - getAllUsers
        [TestMethod]
        public void getAllUsers(){

            // Arrange
            User user = new User();
            user.ChangeEmail("foo5@example.com");
            _harness.Add(user);

            // Act
            IEnumerable<BaseEntity> users =  _harness.GetAll();
            bool hasUsers = false;

            if (users.Count() > 0) {
                hasUsers = true; 
            }

            // Assert
            Assert.AreEqual(hasUsers, true);
        }

        

    }
}