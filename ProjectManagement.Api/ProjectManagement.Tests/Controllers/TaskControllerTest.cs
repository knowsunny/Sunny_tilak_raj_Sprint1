using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Api.Controllers;
using ProjectManagement.Data.Implementation;
using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;
using ProjectManagement.Services;
using ProjectManagement.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TaskManagement.Tests
{
    public class TaskControllerTest
    {

        private TaskService _service;
        private IBaseRepository<Task> _repository;
        private const string V = "Mar 18 2021";
        public PMContext _context;
        public TaskControllerTest()
        {
            //opt => opt.UseInMemoryDatabase("projectManagementApp")
            var option = new DbContextOptionsBuilder<PMContext>()
            .UseInMemoryDatabase(databaseName: "projectmanagementtest")
            .Options;

            _context = new PMContext(option);

            _repository = new BaseRepository<Task>(_context);
            _service = new TaskService(_repository);


        }
        [Fact]
        public void Task_GetTaskById_Return_NotFoundResult()
        {
            var controller = new TaskController(_service);
            var userId = 12;

            var data = controller.Get(userId);
            Assert.IsType<NotFoundResult>(data);
        }


        [Fact]
        public void Task_GetTaskById_Return_OkResult()
        {
            Task testTask1 = new Task
            {
                Id = 3,
                ProjectID = 1,
                Detail = "this is a task 1 for management project1",
                CreatedOn = DateTime.Parse(V),
                Status = ProjectManagement.Entities.Enums.TaskStatus.New,
                AssignedToUserID = 1
            };
            _context.Tasks.Add(testTask1);
            _context.SaveChanges();
            var controller = new TaskController(_service);
            var TaskId = 3;

            var data = controller.Get(TaskId);
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_CreateTaskTest()
        {
            Task testTask2 = new Task
            {
                Id = 6,
                ProjectID = 4,
                Detail = "this is a task 2 for management project1",
                CreatedOn = DateTime.Parse(V),
                Status = ProjectManagement.Entities.Enums.TaskStatus.InProgress,
                AssignedToUserID = 2
            };
            var controller = new TaskController(_service);

            var data = controller.CreateTask(testTask2);

            Assert.IsType<OkObjectResult>(data);
        }



        [Fact]
        public void Task_updateTask_Return_OkResult()
        {
            Task testTask1 = new Task
            {
                Id = 3,
                ProjectID = 1,
                Detail = "this is a task 1 for management project1 is updated",
                CreatedOn = DateTime.Parse(V),
                Status = ProjectManagement.Entities.Enums.TaskStatus.New,
                AssignedToUserID = 1
            };

            var controller = new TaskController(_service);

            var data = controller.UpdateTask(testTask1);

            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_GetAllTask_Test()
        {
            var controller = new TaskController(_service);
            var data = controller.GetAllTask();
            Assert.IsType<OkObjectResult>(data);
        }


        [Fact]
        public void Task_TaskDelete_OkResult()
        {
            var controller = new TaskController(_service);

            var data = controller.DeleteTask(4);

            Assert.IsType<OkObjectResult>(data);
        }
    }
}
