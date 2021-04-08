using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Api.Controllers;
using ProjectManagement.Data.Implementation;
using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;
using ProjectManagement.Services;
using ProjectManagement.Shared;
using System;
using System.Net;
using Xunit;

namespace ProjectManagement.Tests
{
    public class UserControllerTest
    {

        private UserService _service;
        private UserRepository _userrepo;
        private  IBaseRepository<User> _repository;

        public PMContext _context;
        public UserControllerTest()
        {
            //opt => opt.UseInMemoryDatabase("projectManagementApp")
            var option = new DbContextOptionsBuilder<PMContext>()
            .UseInMemoryDatabase(databaseName: "projectmanagementtest")
            .Options;

            _context = new PMContext(option);

            _repository = new BaseRepository<User>(_context);
            _userrepo = new UserRepository(_context);
            _service = new UserService(_repository, _userrepo);
            
            
        }
        [Fact]
        public void Task_GetUserById_Return_NotFoundResult()
        {
            var controller = new UserController(_service);
            var userId = 12;

            var data = controller.GetUserById(userId);
            Assert.IsType<NotFoundResult>(data);
        }


        [Fact]
        public void Task_GetUserById_Return_OkResult()
        {
            User testUser2 = new User
            {
                Id = 2,
                Email = "harsh@xyz.com",
                FirstName = "Harsh",
                LastName = "Verma",
                Password = "forgetit"
            };
            _context.Users.Add(testUser2);
            _context.SaveChanges();
            var controller = new UserController(_service);
            var userId = 2;

            var data = controller.GetUserById(userId);
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_CreateUserTest()
        {
            User testUser1 = new User
            {
                Id = 1,
                Email = "sunny@xyz.com",
                FirstName = "Sunny",
                LastName = "Kumar",
                Password = "changeit"
            };

            var controller = new UserController(_service);

            var data = controller.CreateUser(testUser1);

            Assert.IsType<OkObjectResult>(data);
        }

        

        [Fact]
        public void Task_updateUser_Return_OkResult()
        {
            User testUser1 = new User
            {
                Id = 1,
                Email = "sunnychange@xyz.com",
                FirstName = "Sunny",
                LastName = "Kumar",
                Password = "changeit"
            };

            var controller = new UserController(_service);

            var data = controller.UpdateUser(testUser1);

            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_GetAllUsers_Test()
        {
            var controller = new UserController(_service);
            var data = controller.GetAllUsers();
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_UserLogin_OkResult()
        {
            var controller = new UserController(_service);
            User testUser2 = new User
            {
                Id = 40,
                Email = "harsh@xyz.com",
                FirstName = "Harsh",
                LastName = "Verma",
                Password = "forgetit"
            };
            _context.Users.Add(testUser2);
            _context.SaveChanges();
            var data = controller.UserLogin(testUser2);

            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_UserLogin_NoResult()
        {
            var controller = new UserController(_service);
            User testUser1 = new User
            {
                Id = 3,
                Email = "sunny@xyz.com",
                FirstName = "Sunny",
                LastName = "Kumar",
                Password = "changei32t"
            };
            var data = controller.UserLogin(testUser1);

            Assert.IsType<NotFoundObjectResult>(data);
        }

        [Fact]
        public void Task_userDelete_OkResult()
        {
            var controller = new UserController(_service);
            User testUser2 = new User
            {
                Id = 2,
                Email = "harsh@xyz.com",
                FirstName = "Harsh",
                LastName = "Verma",
                Password = "forgetit"
            };
            //_context.Users.Add(testUser2);
           // _context.SaveChanges();
            var data = controller.DeleteUser(2);

            Assert.IsType<OkObjectResult>(data);
        }
    }
}
