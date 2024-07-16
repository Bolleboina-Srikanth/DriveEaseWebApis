using BusinessLayer.Interface;
using BusinessLayer.Services;
using CarRentalSystem.Controllers;
using CloudinaryDotNet;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Services;
using System.Collections.Generic;

namespace UserControllerTests
{
    [TestClass]
    public class Cartest
    {
        [TestMethod]
        public void AddCarTestCase()
        {
            //Arrange
            var mockRepo = new Mock<ICarBusiness>();
            mockRepo.Setup(repo => repo.AddCars(It.IsAny<CarsModel>()))
                .Returns("Car added successfully");

            var controller = new CarController(mockRepo.Object);
            var carData = new CarsModel
            {


            };
            var result = controller.AddCars(carData) as OkObjectResult;
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Car added successfully", result.Value.GetType().GetProperty("data").GetValue(result.Value));
        }

        [TestMethod]
        public void UpdateCarTestCase()
        {
            //Arrange
            var carData = new UpdateCarModel
            {
                carName = "Tiago",
                carBrand = "Tata",
                carNumber = "TS23QW1234",
                transmission = "Automatic",
                fuel = "petrol",
                carColor = "Red",
                seating = "5",
                carStatus = "Available",
                priceperHour = 244,
                priceperDay = 999,
                state = "",
                district = "",
                place = ""
            };

            var mockRepo = new Mock<ICarBusiness>();
            mockRepo.Setup(repo => repo.UpdateCar(It.IsAny<UpdateCarModel>()))
                .Returns(new CarEntity());

            var controller = new CarController(mockRepo.Object);

            //Act
            var result = controller.UpdateCars(carData);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, (result as ObjectResult)?.StatusCode);
        }

        [TestMethod]
        public void UpdateCarTestFailedCase()
        {
            //Arrange
            var carData = new UpdateCarModel
            {
                  carName = "Tiago",
                  carBrand = "Tata",
                  carNumber = "TS23QW1234",
                  transmission = "Automatic",
                  fuel          = "petrol",
                  carColor     =   "Red",
                  seating    =      "5",
                  carStatus    =   "Available",
                  priceperHour =    244,
                  priceperDay   =   999,
                  state         =   "",
                  district      = "",
                  place         = ""
            };

            var mockRepo = new Mock<ICarBusiness>();
            mockRepo.Setup(repo => repo.UpdateCar(It.IsAny<UpdateCarModel>()))
                .Returns<CarEntity>(null);

            var controller = new CarController(mockRepo.Object);

            //Act
            var result = controller.UpdateCars(carData) ;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status400BadRequest, (result as ObjectResult)?.StatusCode);
        }

        [TestMethod]
        public void DeleteCarTestCase1()
        {
            //Arrange
            int carid = 4;

            var mockRepo = new Mock<ICarBusiness>();
            mockRepo.Setup(repo => repo.DeleteCar(carid))
                .Returns("car deleted successfully");

            var controller = new CarController(mockRepo.Object);

            //Act
            var result = controller.DeleteCar(carid);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, (result as ObjectResult)?.StatusCode);
        }

        [TestMethod]
        public void DeleteCarTestCase2()
        {
            //Arrange
            int carid = 4;

            var mockRepo = new Mock<ICarBusiness>();
            mockRepo.Setup(repo => repo.DeleteCar(carid))
                .Returns((string)null);

            var controller = new CarController(mockRepo.Object);

            //Act
            var result = controller.DeleteCar(carid) ;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status400BadRequest, (result as ObjectResult)?.StatusCode);
        }

        [TestMethod]
        public void GetAllCarsTestCase()
        {
            var mockRepo = new Mock<ICarBusiness>();
            mockRepo.Setup(repo => repo.GetAllCars())
                .Returns(new List<CarEntity>());

            var controller = new CarController(mockRepo.Object);

            //Act
            var result = controller.GetAllCars();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, (result as ObjectResult)?.StatusCode);
        }

        [TestMethod]
        public void AdditionTest()
        {
            int a = 5;
            int b = 9;
            int result = Sum(a, b);
            Assert.AreEqual(a + b, result);
        }


        public int Sum(int a, int b)
        {
            return a - b;
        }

    }   
}
