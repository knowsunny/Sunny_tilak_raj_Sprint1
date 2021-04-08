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
    public class ProjectControllerTest
    {

        private ProjectService _service;
        private IBaseRepository<Project> _repository;
        private const string V = "Mar 18 2021";
        public PMContext _context;
        public ProjectControllerTest()
        {
            //opt => opt.UseInMemoryDatabase("projectManagementApp")
            var option = new DbContextOptionsBuilder<PMContext>()
            .UseInMemoryDatabase(databaseName: "projectmanagementtest")
            .Options;

            _context = new PMContext(option);

            _repository = new BaseRepository<Project>(_context);
            _service = new ProjectService(_repository);


        }
        [Fact]
        public void Task_GetProjectById_Return_NotFoundResult()
        {
            var controller = new ProjectController(_service);
            var userId = 12;

            var data = controller.Get(userId);
            Assert.IsType<NotFoundResult>(data);
        }


        [Fact]
        public void Task_GetProjectById_Return_OkResult()
        {
            Project testproject1 = new Project
            {
                Id = 4,
                Name = "ProjectManagement",
                Detail = "this is a project management project",
                CreatedOn = DateTime.Parse(V)
            };
            _context.Projects.Add(testproject1);
            _context.SaveChanges();
            var controller = new ProjectController(_service);
            var ProjectId = 4;

            var data = controller.Get(ProjectId);
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_CreateProjectTest()
        {
            Project testproject2 = new Project
            {
                Id = 5,
                Name = "ProjectManagement2",
                Detail = "this is a project management project2",
                CreatedOn = DateTime.Parse(V)
            };
            var controller = new ProjectController(_service);

            var data = controller.CreateProject(testproject2);

            Assert.IsType<OkObjectResult>(data);
        }



        [Fact]
        public void Task_updateProject_Return_OkResult()
        {
            Project testproject1 = new Project
            {
                Id = 4,
                Name = "ProjectManagementupdated",
                Detail = "this is a project management project",
                CreatedOn = DateTime.Parse(V)
            };

            var controller = new ProjectController(_service);

            var data = controller.UpdateProject(testproject1);

            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_GetAllProject_Test()
        {
            var controller = new ProjectController(_service);
            var data = controller.GetAllProject();
            Assert.IsType<OkObjectResult>(data);
        }


        [Fact]
        public void Task_ProjectDelete_OkResult()
        {
            var controller = new ProjectController(_service);
            
            var data = controller.DeleteProject(4);

            Assert.IsType<OkObjectResult>(data);
        }
    }
}
