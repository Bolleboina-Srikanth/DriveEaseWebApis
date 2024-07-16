using BusinessLayer.Interface;
using BusinessLayer.Services;
using CarRentalSystem.Controllers;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System.Threading.Tasks;

namespace UserControllerTests
{
    [TestClass]
    public class UnitTest1
    {
        private  Mock<IUserRepo> _mockUserrepo;
        private  UserBusiness _userBusiness;

        [TestInitialize]
        public void SetUp()
        {
            _mockUserrepo = new Mock<IUserRepo>();
            _userBusiness = new UserBusiness(_mockUserrepo.Object);

        }

        [TestMethod]
        public void SignUpTestCase1()
        {
            // Arrange
            var mockUserBusiness = new Mock<IUserBusiness>();
            mockUserBusiness.Setup(x => x.UserRegisteration(It.IsAny<UserRegisterationModel>()))
                            .Returns("successfully registered");
            var controller = new UserController(mockUserBusiness.Object);
            var model = new UserRegisterationModel
            {
                name = "Srikanth",
                phoneNumber = "8333035555",
                state = "Telangana",
                city = "Warangal",
                address = "Dharmaram",
                role = "Admin",
                status = "Active",
                licenseNumber = "TSAM-348193",
                email = "srikanthbolleboina6@gmail.com",
                password = "Sky@123"
            };

            // Act
            var result = controller.Registeration(model) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("successfully registered", result.Value.GetType().GetProperty("data").GetValue(result.Value));
        }

        [TestMethod]
        public  void SignUpTestCase2()
        {
            //Arrange
            var mockRepo = new Mock<IUserBusiness>();
            mockRepo.Setup(repo => repo.UserRegisteration(It.IsAny<UserRegisterationModel>()))
                .Returns("You already have an account");

            var controller = new UserController(mockRepo.Object);
            var userData = new UserRegisterationModel
            {
                name = "Srikanth",
                phoneNumber = "8333035555",
                state = "Telangana",
                city = "Warangal",
                address = "Dharmaram",
                role = "Admin",
                status = "Active",
                licenseNumber = "TSAM-348193",
                email = "srikanthbolleboina6@gmail.com",
                password = "Sky@123"
            };
            var result =  controller.Registeration(userData) as OkObjectResult;
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("You already have an account", result.Value.GetType().GetProperty("data").GetValue(result.Value));
        }

     
    }

    

}
