using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Api.Controllers
{
    [ApiController]
    [Route("api/Task")]
    public class TaskController : BaseController<ProjectManagement.Entities.Task>
    {
        ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            this._taskService = taskService;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id > 0)
            {
                var task = _taskService.GetTaskByTaskId(id);
                if (task == null)
                {
                    return NotFound();
                }
                return Ok(task);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] ProjectManagement.Entities.Task task)
        {
            var isTaskCreationSuccessful =  _taskService.Create(task);

            return Ok(isTaskCreationSuccessful);
        }

        [HttpPut]
        public IActionResult UpdateTask([FromBody]  ProjectManagement.Entities.Task task)
        {
            var isTaskUpdationSuccessful =  _taskService.Update(task);

            return Ok(isTaskUpdationSuccessful);
        }

        [HttpGet]
        public IActionResult GetAllTask()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(long id)
        {
            var isProjectDeleted = _taskService.Delete(id);
            return Ok(isProjectDeleted);
        }
    }
}
