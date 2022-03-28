﻿using FCCodingChallenge.API.Controllers;
using FCCodingChallenge.API.Data;
using FCCodingChallenge.API.Data.Models;
using FCCodingChallenge.API.Data.ViewModels;
using FCCodingChallenge.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FCCodingChallenge.Tests
{
    [TestClass]
    public  class UserControllerTests
    {
        private readonly Mock<IUserService> userServiceStub = new ();
        private readonly IHttpContextAccessor httpServiceStub;
        private readonly Mock<IUserRoleService> userRoleServiceStub = new ();
        private readonly Mock<RemoteDetails> remoteDetailsStub = new ();
        private readonly Mock<ILoggerManager> loggerStub = new ();
        [TestMethod]
        public async Task GetUser_WithUnExistingEmail_ReturnsNull()
        {
            //Arrange
            userServiceStub.Setup(repo => repo.GetUser(It.IsAny<string>())).ReturnsAsync((GenericResponse<User>)null);

            var controller = new UserController(userServiceStub.Object, userRoleServiceStub.Object, httpServiceStub, remoteDetailsStub.Object, loggerStub.Object);

            //Act
            var result = await controller.GetUser("stub@gmail.com") as OkObjectResult;

            //Asser
            Assert.AreEqual(result.Value, null);
        }

        [TestMethod]
        public async Task GetUser_WithUnExistingEmail_ReturnsUser()
        {
            var expectedUser = CreateRandomUser();

            userServiceStub.Setup(repo => repo.GetUser(It.IsAny<string>())).ReturnsAsync(expectedUser);

            var controller = new UserController(userServiceStub.Object, userRoleServiceStub.Object, httpServiceStub, remoteDetailsStub.Object, loggerStub.Object);

            //Act
            var result = await controller.GetUser(expectedUser.Data.Email) as OkObjectResult;

            //Assert
            var data = JsonConvert.DeserializeObject<GenericResponse<User>>((string)result.Value);
            Assert.AreEqual(result.Value, data.Data);
        }

        [TestMethod]
        public async Task CreateUser_WithNewDetails_ReturnsOk()
        {
            var newUser = new UserVM
            {
                Email = Guid.NewGuid().ToString(),
                Firstname = Guid.NewGuid().ToString(),
                Lastname = Guid.NewGuid().ToString(),
                Gender = Guid.NewGuid().ToString(),
                Phone = Guid.NewGuid().ToString(),
                Nationality = Guid.NewGuid().ToString(),
                Role = "Admin"
            };

            //userRoleServiceStub.Setup(repo => repo.AddUserRole(It.IsAny<string>())).ReturnsAsync(newUser);

            var controller = new UserController(userServiceStub.Object, userRoleServiceStub.Object, httpServiceStub, remoteDetailsStub.Object, loggerStub.Object);

            //Act
            var result = await controller.AddUser(newUser);

            //Assert
            var response = (result as OkObjectResult);
            Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode);
        }


        private GenericResponse<User> CreateRandomUser()
        {
            return new()
            {
                IsSuccessful = true,
                ResponseCode = "00",
                ResponseMessage = "Success",
                Data = new()
                {
                    DateCreated = DateTime.Now,
                    DateOfBirth = DateTime.Now.ToString("yyyy-MM-dd"),
                    Email = Guid.NewGuid().ToString(),
                    Firstname = Guid.NewGuid().ToString(),
                    Lastname = Guid.NewGuid().ToString(),
                    Gender = Guid.NewGuid().ToString(),
                    Phone = Guid.NewGuid().ToString(),
                    IsDeleted = false,
                    Nationality = Guid.NewGuid().ToString()
                }
            };
        }
    }
}
